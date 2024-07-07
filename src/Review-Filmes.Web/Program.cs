using Microsoft.EntityFrameworkCore;
using Prometheus;
using ReviewFilmes.Api.Entity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adiciona serviços ao contêiner.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Método para abrir a conexão com repetição em caso de falha
async Task<bool> EnsureDatabaseConnectionAsync(AppDbContext dbContext, int maxRetries = 3, int delayMilliseconds = 1000)
{
    int attempt = 0;
    while (true)
    {
        try
        {
            await dbContext.Database.OpenConnectionAsync();
            return true; // Conexão bem-sucedida
        }
        catch (SocketException ex) when (ex.SocketErrorCode == SocketError.TimedOut || ex.SocketErrorCode == SocketError.TryAgain)
        {
            if (++attempt == maxRetries)
            {
                return false; // Falha após número máximo de tentativas
            }
            await Task.Delay(delayMilliseconds); // Espera antes de tentar novamente
        }
        catch (Exception)
        {
            return false; // Qualquer outra exceção
        }
    }
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (await EnsureDatabaseConnectionAsync(db))
    {
        db.Database.Migrate();
    }
    else
    {
        // Log ou tratamento adicional caso a conexão falhe
        Console.WriteLine("Falha ao conectar ao banco de dados após várias tentativas.");
    }
}

// Configura o pipeline de solicitação HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();
app.UseHttpMetrics();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapMetrics();
});

app.Run();

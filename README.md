# DevOps4Devs 02

## Aula 01
### O projeto conversão de temperatura se encontra no link abaixo:

[https://github.com/KubeDev/conversao-temperatura](https://github.com/KubeDev/conversao-temperatura)

## Aula 02
### Comando de criação do cluster Kubernetes com o K3D
```bash
k3d cluster create meucluster --servers 3 --agents 3 -p "30000:30000@loadbalancer"
```


## Aula 03

### Link para a AWS:

[https://aws.amazon.com](https://aws.amazon.com)

### Link para instalação do AWS CLI:

[https://aws.amazon.com/pt/cli](https://aws.amazon.com/pt/cli)

### URL do template usado do Cloud Formation:
```
https://s3.us-west-2.amazonaws.com/amazon-eks/cloudformation/2020-10-29/amazon-eks-vpc-private-subnets.yaml
```

# Aula 04

# Aula 05 

### Comando para obter a senha do Grafana
```
kubectl get secret --namespace default grafana -o jsonpath="{.data.admin-password}" | base64 --decode
```


# Desafio

# Informações do desafio
Você foi contratado como engenheiro DevOps na empresa "FilmReviews Inc." e vai participar do desenvolvimento e entrega do principal produto da empresa, o "Review de Filmes".

Esse projeto é uma aplicação desenvolvida em C# e vocês estão em processo de prova de conceito, onde deve ser testado o deploy da aplicação em um ambiente Kubernetes.

Seu desafio é fazer um fork do projeto original e fazer esse deploy em um ambiente local para fins de testes utilizando o K3D.

# Requisitos
1.**Criação dos Elementos:**
1.**Criação dos Elementos**:
Crie os manifests necessários para o deploy da aplicação no Kubernetes local, incluindo Deployment e Service.
Utilize o K3D para criar um cluster Kubernetes local.

2.**Eficiência do Deploy e Comportamento**:
Garanta que o deploy da aplicação seja eficiente e que a aplicação esteja funcionando corretamente.
Implemente a escalabilidade e resiliência da aplicação através do Kubernetes.
Teste a capacidade de fazer rollbacks e atualizações sem downtime.

3.**Documentação do Projeto**:
Documente todo o processo de configuração e deploy no arquivo `README-DESAFIO.md` do repositório.
Inclua os comandos utilizados e screenshots dos resultados.

## UserMicroservice

Criar uma pasta com o nome UserMicroservice e clonar o repo para dentro desta pasta

## Criar o banco de Dados

E necessario ter o docker-compose instalado e estar na pasta principal do projeto onde esta o arquivo do docker-compose:
`docker-compose up -d`

## Após subir o banco de dados criar as Migrations:
`dotnet ef migrations add InitialCreate`
## Depois executar o: 
`dotnet ef database update`

#### Rodando o projeto

Iniciar o Projeto com:
`dotnet run`




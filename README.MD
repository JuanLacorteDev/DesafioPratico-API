# DesafioPraticoAPI
Desenvolida aplicação WEB REST API para processo seletivo
Aplicação construindo realizando a divisão das camadas de negocio e acesso a dados do projeto de API, visando escalabilidade e manutenção.

para rodar o projeto no arquivo appsettings.json altere o servidor da connectionString para o seu servidor de dados 
"ConexaoPracticalChallenge": "Server={SEU SERVER AQUI!!};Database=PracticalChallengeDb;Trusted_Connection=True;MultipleActiveResultSets=true"
logo apos abre o Package Manager Console e rode o comando update-database para serem aplicas as migrations e o banco ser criados com sua tabela produtos.
certifique que o seu serve de banco esta ativo.

e rode a aplicação startup como a PracticalChallenge.Api.

# TravelRouteCalculator
Esta API é responsável pela gestão e busca otimizada de rotas de viagem, permitindo identificar os melhores caminhos entre origens e destinos especificados. Funcionalidades incluem cálculo do caminho mais curto e do mais econômico, baseando-se em dados de distância e custo.


# Instruções
Para configurar e iniciar este projeto, que utiliza o Entity Framework para interação com o banco de dados SQL Server, siga os passos abaixo. Antes de começar, certifique-se de adaptar o arquivo appsettings.json com suas informações de conexão ao banco de dados, especificamente na chave ConnectionStrings.

# 1-Configuração da String de Conexão:
Abra o arquivo appsettings.json localizado na raiz do projeto API. Modifique a propriedade ConnectionStrings com os detalhes de conexão ao seu banco de dados SQL Server.

"ConnectionStrings": {
    "DefaultConnection": "Server=seu_servidor;Database=seu_banco_de_dados;User Id=seu_usuario;Password=sua_senha;"
}

# 2-Geração das Migrações:
Geração das Migrações:
Utilize o Package Manager Console do Visual Studio para criar a migração inicial do banco de dados. Certifique-se de que o console está configurado para usar o projeto CadastroRotasRepository como o projeto padrão e CadastroRotasAPI como o projeto de inicialização. Execute o seguinte comando para criar a migração:

Add-Migration Init-Project -Project CadastroRotasRepository -StartupProject CadastroRotasAPI -Context ApplicationDbContext

# 3-Aplicação das Migrações e Criação do Banco de Dados:
Após a criação da migração, você deve aplicá-la para efetivamente criar o banco de dados e suas tabelas correspondentes. Ainda no Package Manager Console, execute o comando:

Update-Database -Context ApplicationDbContext -Project CadastroRotasRepository -StartupProject CadastroRotasAPI

Este comando aplica a migração ao banco de dados, criando-o com o esquema necessário para o funcionamento do projeto.
Ao seguir estas instruções, seu ambiente estará configurado e pronto para executar o projeto com o banco de dados devidamente estruturado.

# 4-Json com algumas Rotas:

[
  {
    "origem": "GRU",
    "destino": "BRC",
    "custo": 10
  },
  {
    "origem": "BRC",
    "destino": "SCL",
    "custo": 5
  },
  {
    "origem": "GRU",
    "destino": "CDG",
    "custo": 75
  },
  {
    "origem": "GRU",
    "destino": "SCL",
    "custo": 20
  },
  {
    "origem": "GRU",
    "destino": "ORL",
    "custo": 56
  },
  {
    "origem": "ORL",
    "destino": "CDG",
    "custo": 5
  },
  {
    "origem": "SCL",
    "destino": "ORL",
    "custo": 20
  },
  {
    "origem": "GRU",
    "destino": "BSB",
    "custo": 200
  },
  {
    "origem": "BSB",
    "destino": "REC",
    "custo": 250
  },
  {
    "origem": "GRU",
    "destino": "CWB",
    "custo": 150
  },
  {
    "origem": "GRU",
    "destino": "POA",
    "custo": 180
  },
  {
    "origem": "GRU",
    "destino": "GIG",
    "custo": 120
  },
  {
    "origem": "GIG",
    "destino": "SSA",
    "custo": 300
  },
  {
    "origem": "POA",
    "destino": "FLN",
    "custo": 160
  },
  {
    "origem": "CWB",
    "destino": "BEL",
    "custo": 350
  },
  {
    "origem": "SSA",
    "destino": "MCZ",
    "custo": 100
  },
  {
    "origem": "FLN",
    "destino": "VIX",
    "custo": 140
  },
  {
    "origem": "BEL",
    "destino": "NAT",
    "custo": 370
  },
  {
    "origem": "MCZ",
    "destino": "FOR",
    "custo": 90
  },
  {
    "origem": "VIX",
    "destino": "CGH",
    "custo": 200
  },
  {
    "origem": "CGH",
    "destino": "SDU",
    "custo": 110
  },
  {
    "origem": "SDU",
    "destino": "AJU",
    "custo": 280
  },
  {
    "origem": "AJU",
    "destino": "THE",
    "custo": 230
  },
  {
    "origem": "THE",
    "destino": "CPV",
    "custo": 210
  },
  {
    "origem": "CPV",
    "destino": "JPA",
    "custo": 80
  },
  {
    "origem": "JPA",
    "destino": "GRU",
    "custo": 400
  },
  {
    "origem": "NAT",
    "destino": "BPS",
    "custo": 330
  },
  {
    "origem": "BSB",
    "destino": "SSA",
    "custo": 250
  },
  {
    "origem": "CWB",
    "destino": "POA",
    "custo": 200
  },
  {
    "origem": "CNF",
    "destino": "VIX",
    "custo": 150
  },
  {
    "origem": "MAO",
    "destino": "BEL",
    "custo": 350
  },
  {
    "origem": "REC",
    "destino": "FOR",
    "custo": 180
  },
  {
    "origem": "GYN",
    "destino": "PMW",
    "custo": 230
  },
  {
    "origem": "SLZ",
    "destino": "THE",
    "custo": 220
  },
  {
    "origem": "PVH",
    "destino": "RBR",
    "custo": 360
  },
  {
    "origem": "CGR",
    "destino": "CGB",
    "custo": 190
  }
]







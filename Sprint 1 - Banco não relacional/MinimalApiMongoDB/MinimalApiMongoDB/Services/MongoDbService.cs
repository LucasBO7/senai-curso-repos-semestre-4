using MongoDB.Driver;

namespace MinimalApiMongoDB.Services
{
    public class MongoDbService()
    {
        /// <summary>
        /// Armazenar a configuração da aplicação
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Armazena uma referência ao MongoDB
        /// </summary>
        private readonly IMongoDatabase _database;

        /// <summary>
        /// Construtor que contém a configuração necessária para acesso ao MongoDb
        /// </summary>
        /// <param name="configuration">Obj com a configuração da aplicação</param>
        public MongoDbService(IConfiguration configuration) : this()
        {
            // Atribui a config recebida à _configuration
            _configuration = configuration;

            // Recebe a string de conexão
            // "DbConnection" é a chave cuja atribuição de valor está contida na appsettings.json
            string connectionString = _configuration.GetConnectionString("DbConnection")!;

            // Transforma a string de conexão em MongoUrl
            MongoUrl mongoUrl = MongoUrl.Create(connectionString);

            // Cria um client
            MongoClient mongoClient = new(mongoUrl);

            // Pega o banco de dados (em MongoDb) e associa-o com o atributo "_database"
            _database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
        }

        /// <summary>
        /// Propriedade para acessar o banco de dados => retorna os dados em _database
        /// </summary>
        /// <returns></returns>
        public IMongoDatabase GetDatabase() => _database;

    }
}
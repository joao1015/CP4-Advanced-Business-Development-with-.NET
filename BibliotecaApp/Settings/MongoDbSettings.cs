namespace BibliotecaApp.Settings
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; } = default!;
        public string DatabaseName { get; set; } = "BibliotecaDb";
        public string CollectionName { get; set; } = "Livros";
    }
}

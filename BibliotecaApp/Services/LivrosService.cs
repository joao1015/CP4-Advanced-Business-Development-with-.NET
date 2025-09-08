using BibliotecaApp.Models;
using BibliotecaApp.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BibliotecaApp.Services
{
    public class LivrosService
    {
        private readonly IMongoCollection<Livro> _livros;

        public LivrosService(IOptions<MongoDbSettings> options)
        {
            var cfg = options.Value;
            var client = new MongoClient(cfg.ConnectionString);
            var database = client.GetDatabase(cfg.DatabaseName);
            _livros = database.GetCollection<Livro>(cfg.CollectionName);
        }

        public async Task<List<Livro>> GetAsync() =>
            await _livros.Find(_ => true).ToListAsync();

        public async Task<Livro?> GetByIdAsync(string id) =>
            await _livros.Find(l => l.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Livro livro)
        {
            await _livros.InsertOneAsync(livro);
        }

        public async Task<bool> UpdateAsync(string id, Livro livro)
        {
            livro.Id ??= id;
            var result = await _livros.ReplaceOneAsync(l => l.Id == id, livro);
            return result.ModifiedCount > 0;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _livros.DeleteOneAsync(l => l.Id == id);
            return result.DeletedCount > 0;
        }
    }
}

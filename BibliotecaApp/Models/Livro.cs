using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaApp.Models
{
    public class Livro
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [Required]
        public string Titulo { get; set; } = default!;

        [Range(1, 3000)]
        public int Ano { get; set; }

        [Required]
        public Autor Autor { get; set; } = default!;
    }
}

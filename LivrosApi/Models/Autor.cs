using System.Text.Json.Serialization;

namespace LivrosApi.Models;

public class Autor
{
    public int Id { get; set; }
    
    public string Nome { get; set; }
    
    public string Sobrenome { get; set; }
    
    [JsonIgnore]
    public ICollection<Livro> Livros { get; set; }

}
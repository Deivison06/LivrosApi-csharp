using LivrosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LivrosApi.Data;

public class AppdbContext: DbContext
{

    public AppdbContext(DbContextOptions<AppdbContext> options): base(options){}
    
    public DbSet<Autor> Autors { get; set; }
    
    public DbSet<Livro> Livros { get; set; }
    
}
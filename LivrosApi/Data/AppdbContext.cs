using Microsoft.EntityFrameworkCore;

namespace LivrosApi.Data;

public class AppdbContext: DbContext
{

    public AppdbContext(DbContextOptions<AppdbContext> options): base(options){}
    
    
    
}
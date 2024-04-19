using Cadastro.Usuarios.Models;
using Microsoft.EntityFrameworkCore;

namespace Cadastro.Data;

public class AppDbContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
     
        optionsBuilder.UseMySQL(connectionString: "Server=192.168.0.41;Database=cadastro;Uid=suellen;Pwd=cadastro;");
        optionsBuilder.LogTo(Console.WriteLine,LogLevel.Information);
            base.OnConfiguring(optionsBuilder);
    }
    
}
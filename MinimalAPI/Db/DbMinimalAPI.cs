using Microsoft.EntityFrameworkCore;
using MinimalAPI.Entidades;
using MinimalAPI.Models;

namespace MinimalAPI.Db;

public class DbMinimalAPI: DbContext
{

    public DbMinimalAPI(DbContextOptions<DbMinimalAPI> options) : base(options) { }
    public DbSet<Administrador> Administradors { get; set; } 
    public DbSet<Veiculos> Veiculos { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrador>().HasData(
            new Administrador
            {
                Id = 1,
                Email = "Administrador",
                Senha = "123456",
                Perfil = "Adm"
            });
    }

}
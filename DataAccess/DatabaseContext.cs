using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Item> Itens { get; set; }
    public DbSet<Reciclador> Recicladores { get; set; }

    //public DbSet<Usuario> Usuarios { get; set; }

    //public DbSet<Permissao> Permissoes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Item>()
            .HasKey(_ => _.Id);
        modelBuilder
            .Entity<Item>()
            .HasOne(_ => _.Categoria)
            .WithMany(_ => _.Itens);

        modelBuilder
            .Entity<Categoria>()
            .HasKey(_ => _.Id);

        modelBuilder
           .Entity<Reciclador>()
           .HasKey(_ => _.Id);

        //modelBuilder
        //	.Entity<Permissao>()
        //	.HasKey(_ => _.Id);

        //modelBuilder
        //	.Entity<Usuario>()
        //	.HasKey(_ => _.Id);
        //modelBuilder
        //	.Entity<Usuario>()
        //	.HasOne(_ => _.Permissao)
        //	.WithMany(_ => _.Usuarios);
    }
}

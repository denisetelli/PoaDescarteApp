using DataAccess.Models;
using System.Linq;

public static class DatabaseInitializer
{
    public static void Initializer(DatabaseContext context)
    {
        context.Database.EnsureCreated();

        //var mainRole = new Permissao { Id = 1, Tipo = "Admin" };
        //if (!context.Permissoes.Any())
        //{
        //    context.Permissoes.Add(mainRole);
        //    context.Permissoes.Add(new Permissao { Id = 2, Tipo = "User" });
        //}

        if (!context.Categorias.Any())
        {
            context.Categorias.Add(new Categoria { Id = 0, Nome = "Papel" });
            context.Categorias.Add(new Categoria { Id = 0, Nome = "Vidro" });
            context.Categorias.Add(new Categoria { Id = 0, Nome = "Metal" });
            context.Categorias.Add(new Categoria { Id = 0, Nome = "Eletrônico" });
            context.Categorias.Add(new Categoria { Id = 0, Nome = "Plástico" });
            context.Categorias.Add(new Categoria { Id = 0, Nome = "Orgânico" });
        }

        //if (!context.Usuarios.Any())
        //{
        //    var initialUser = new Usuario
        //    {
        //        Nome = "Administrador",
        //        Sobrenome = "Administrador",
        //        Email = "admin@google.com",
        //        Senha = "admin123",//admin123,
        //        Permissao = mainRole
        //    };
        //    context.Usuarios.Add(initialUser);
        //}

        context.SaveChanges();
    }
}

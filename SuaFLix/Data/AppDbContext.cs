using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SuaFLix.Models;

namespace SuaFLix.Data;

// Herança
public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
    {
    }

    public DbSet<Genre> Genres { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<MovieGenre> MovieGenres { get; set; }

    // FluentAPI
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        #region Configurando o Muitos para Muitos do MovieGenre
        
        // Chave Primária Composta
        builder.Entity<MovieGenre>().HasKey(
            mg => new { mg.MovieId, mg.GenreId }
        );
        
        // Chave Estrangeira Movie (m)
        builder.Entity<MovieGenre>()
        .HasOne(mg => mg.Movie)
        .WithMany(m => m.Genres)
        .HasForeignKey(mg => mg.MovieId);

        // Chave Estrangeira do Genre (g)
        builder.Entity<MovieGenre>()
        .HasOne(mg => mg.Genre)
        .WithMany(g => g.Movies)
        .HasForeignKey(mg => mg.GenreId);


        #endregion

        #region Popular Usuários
        // Perfil
        List<IdentityRole> roles = new()
        {
            new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Administrador",
                NormalizedName = "ADMINISTRADOR"
            },
            new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Usuário",
                NormalizedName = "USUÁRIO"
            }
        };
        builder.Entity<IdentityRole>().HasData(roles);
        // User
        List<IdentityUser> users = new()
        {
            new IdentityUser()
            {
                Id = Guid.NewGuid().ToString(),
                Email = "admin@galloflix.com",
                NormalizedEmail = "ADMIN@GALLOFLIX.COM",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                LockoutEnabled = false,
                EmailConfirmed = true
            },
            new IdentityUser()
            {
                Id = Guid.NewGuid().ToString(),
                Email = "user@gmail.com",
                NormalizedEmail = "USER@GMAIL.COM",
                UserName = "User",
                NormalizedUserName = "USER",
                LockoutEnabled = true,
                EmailConfirmed = true
            }
        };
        foreach (var user in users)
        {
            PasswordHasher<IdentityUser> pass = new();
            user.PasswordHash = pass.HashPassword(user, "@Etec123");
        };
        builder.Entity<IdentityUser>().HasData(users);
        // AppUser
        List<AppUser> appUsers = new()
        {
            new AppUser()
            {
                AppUserId = users[0].Id,
                Name = "Erick Reis",
                Birthday = DateTime.Parse("18/06/2003"),
                Photo = "/img/usuarios/avatar.png"
            },
            new AppUser()
            {
                AppUserId = users[1].Id,
                Name = "Fulaninho",
                Birthday = DateTime.Parse("08/05/2000")
            },
        };
        builder.Entity<AppUser>().HasData(appUsers);
        // Perfil Usuário
        List<IdentityUserRole<string>> userRoles = new()
        {
            new IdentityUserRole<string>()
            {
                UserId = users[0].Id,
                RoleId = roles[0].Id
            },
            new IdentityUserRole<string>()
            {
                UserId = users[0].Id,
                RoleId = roles[1].Id
            },
            new IdentityUserRole<string>()
            {
                UserId = users[1].Id,
                RoleId = roles[1].Id
            }
        };
        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        #endregion

    }
}
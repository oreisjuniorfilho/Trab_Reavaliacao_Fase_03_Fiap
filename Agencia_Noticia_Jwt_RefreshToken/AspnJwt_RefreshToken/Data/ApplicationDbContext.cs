using MvcBlogNoticias.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace MvcBlogNoticias.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            //*************************************************************
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            //*************************************************************
            Filme = Set<Noticia>();
        }

        public DbSet<Noticia> Filme { get; set; }       
        //public DbSet<IdentityUser> AspNetUsers { get; set; }
        //public DbSet<IdentityRole> AspNetRoles { get; set; }

    }
}

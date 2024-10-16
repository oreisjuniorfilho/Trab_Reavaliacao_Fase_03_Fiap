using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;


namespace MvcBlogNoticias.Models
{
    public class MvcBlogNoticiasContext : DbContext
    {
        private readonly IConfiguration _configuration;

       public MvcBlogNoticiasContext(DbContextOptions<MvcBlogNoticiasContext> options)
            : base(options)
        {      

        }

        public DbSet<MvcBlogNoticias.Models.Noticia> Filme { get; set; }

        //public class YourDbContextFactory : IDesignTimeDbContextFactory<MvcBlogNoticiasContext>
        //{
        //    public MvcBlogNoticiasContext CreateDbContext(string[] args)
        //    {
        //        var optionsBuilder = new DbContextOptionsBuilder<MvcBlogNoticiasContext>();
        //        optionsBuilder.UseSqlServer("Server=LAPTOP-9BD5LE14\\SQLEXPRESS;Database=db_locadora;Persist Security Info=True;User ID=fiap_user_pos;Password=IR3578#jr;TrustServerCertificate=True");
        //        return new MvcBlogNoticiasContext(optionsBuilder.Options);
        //    }
        //}


    }
}

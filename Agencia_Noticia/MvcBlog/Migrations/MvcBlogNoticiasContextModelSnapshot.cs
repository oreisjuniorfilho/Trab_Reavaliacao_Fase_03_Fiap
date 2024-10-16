using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MvcBlogNoticias.Models;

namespace MvcBlogNoticias.Migrations
{
    [DbContext(typeof(MvcBlogNoticiasContext))]
    partial class MvcBlogNoticiasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MvcBlogNoticias.Models.Filme", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Classificacao");

                    b.Property<string>("Genero");

                    b.Property<DateTime>("Lancamento");

                    b.Property<decimal>("Preco");

                    b.Property<string>("Titulo");

                    b.HasKey("ID");

                    b.ToTable("Filme");
                });
        }
    }
}

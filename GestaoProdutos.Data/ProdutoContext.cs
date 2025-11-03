using GestaoProdutos.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProdutos.Data
{
    public class ProdutoContext : DbContext
    {
        public ProdutoContext(DbContextOptions<ProdutoContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public ProdutoContext()
        {

        }
        public DbSet<Produto> Produtos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().HasData(GetProdutos());

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("Produtos");

                entity.HasKey(p => p.Id);

                entity.Property(p => p.Nome)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(p => p.Descricao)
                      .HasMaxLength(255);

                entity.Property(p => p.Preco)
                      .HasColumnType("decimal(10,2)");

                entity.Property(p => p.Quantidade)
                      .IsRequired();

                entity.Property(p => p.DataCadastro)
                      .HasDefaultValueSql("GETDATE()");

                entity.Property(p => p.Categoria).HasColumnType("INT");

            });


            base.OnModelCreating(modelBuilder);
        }
        private List<Produto> GetProdutos()
        {
            return new List<Produto>
    {
      new Produto {Id = 3, Nome = "Laptop", Preco = 20.5m, Quantidade = 10,
            Descricao ="O melhor laptop para jogos"},
      new Produto {Id = 4, Nome = "Microsoft Office", Preco = 20.99m, Quantidade = 50,
            Descricao ="Aplicação Office"},
      new Produto {Id = 5, Nome = "Lazer Mouse", Preco = 12.02m, Quantidade = 20,
            Descricao ="Um mouse decente"},
      new Produto {Id = 6,  Nome = "USB Storage", Preco = 5.00m, Quantidade = 20,
            Descricao ="Armazena ate 256GB de dados"}
    };
        }
    }
}

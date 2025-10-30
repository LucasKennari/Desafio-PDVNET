using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProdutos.Data
{
    internal class ProdutoContextFactory : IDesignTimeDbContextFactory<ProdutoContext>
    {
        public ProdutoContext CreateDbContext(string[] args)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\GestaoProdutos.UI");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();
            var optionsBuilder = new DbContextOptionsBuilder<ProdutoContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("GestaoProdutosDb"));

            return new ProdutoContext(optionsBuilder.Options);
        }
        
    }
}

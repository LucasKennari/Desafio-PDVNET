using Bogus;
using GestaoProdutos.Business.ProdutoService;
using GestaoProdutos.Data;
using GestaoProdutos.Data.Model;
using GestaoProdutos.Data.ProdutoRepository;
using Microsoft.EntityFrameworkCore;

namespace GestaoProdutos.Tests.Services
{
    public class ProdutoServicesTests
    {
        private readonly IProdutoService _produtoService;
        private readonly IProdutoRepository _produtoRepository;
        private readonly Faker _faker = new("pt_BR");

        public ProdutoServicesTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ProdutoContext>();
            dbContextOptions.UseInMemoryDatabase(databaseName: "ProdutoTestDB");
            var dbContext = new ProdutoContext(dbContextOptions.Options);
            _produtoRepository = new ProdutoRepository(dbContext);
            _produtoService = new ProdutoService(_produtoRepository);
        }
        [Fact(DisplayName = "Dado um produto, valida")]
        public void DadoProdutoValidar()
        {
            var produto = new Data.Model.Produto
            {
                Id = 99999,
                Nome = "Produto Teste",
                Descricao = "Descricao do Produto Teste",
                Preco = 100.00m,
                Quantidade = 20,
            };
            var (resultadoValidacao, mensagemValidacao) = produto.ValidarCampos(produto);
            Assert.True(resultadoValidacao);

        }

        [Fact(DisplayName = "Dado um produto, adicionar")]
        public void DadoUmProdutoValidoAdicionar()
        {
            var produto = new Data.Model.Produto
            {
                Id = 99999,
                Nome = "Produto Teste",
                Descricao = "Descricao do Produto Teste",
                Preco = 100.00m,
                Quantidade = 20,
            };

            var (resultadoValidacao, msgValidacao) = produto.ValidarCampos(produto);
            var (resultado, mensagem) = _produtoService.AddProduto(produto);

            Assert.True(resultadoValidacao);
            Assert.Equal(1, resultado);
        }
        [Fact(DisplayName = "Dado uma lista de produtos, Buscar Todos")]
        public void DadoUmaListaProdutosBuscarTodos()
        {
            List<Produto> produtos = new List<Produto>();
            for (int i = 0; i < 5; i++)
            {
                var produto = new Data.Model.Produto
                {
                    Id = _faker.Random.Number(100000),
                    Nome = _faker.Commerce.ProductName(),
                    Descricao = _faker.Commerce.ProductDescription(),
                    Preco = Decimal.Parse(_faker.Commerce.Price(1, 1000, 2)),
                    Quantidade = _faker.Random.Number(10000),
                };
                produtos.Add(produto);
                _produtoService.AddProduto(produto);
            }

            var resultado = _produtoService.ObterTodos();

            foreach (var item in produtos)
            {
                Assert.Contains(item, resultado);
            }
        }

        [Fact(DisplayName = "Dado um produto, Editar")]
        public void DadoUmProdutoValidoEditar()
        {
            var produto = new Data.Model.Produto
            {
                Id = 99999,
                Nome = _faker.Commerce.ProductName(),
                Descricao = "Descricao do Produto Teste",
                Preco = 100.00m,
                Quantidade = 20,
            };

            var (resultadoValidacao, msgValidacao) = produto.ValidarCampos(produto);
            var resultado = _produtoService.Atualizar(produto);
            Assert.Equal(1, resultado);
        }

        [Fact(DisplayName = "Dado um produto, Deletar")]
        public void DadoUmProdutoValidoDeletar()
        {
            List<Produto> produtos = new List<Produto>();
            for (int i = 0; i < 5; i++)
            {
                var produto = new Data.Model.Produto
                {
                    Id = _faker.Random.Number(100000),
                    Nome = _faker.Commerce.ProductName(),
                    Descricao = _faker.Commerce.ProductDescription(),
                    Preco = Decimal.Parse(_faker.Commerce.Price(1, 1000, 2)),
                    Quantidade = _faker.Random.Number(10000),
                };
                produtos.Add(produto);
                _produtoService.AddProduto(produto);
            }
            var produtoEsperadoExclusao = new Data.Model.Produto
            {
                Id = 999999,
                Nome = _faker.Commerce.ProductName(),
                Descricao = _faker.Commerce.ProductDescription(),
                Preco = Decimal.Parse(_faker.Commerce.Price(1, 1000, 2)),
                Quantidade = _faker.Random.Number(10000),
            };
            produtos.Add(produtoEsperadoExclusao);
            _produtoService.AddProduto(produtoEsperadoExclusao);

            var (resultadoValidacao, msgValidacao) = (false, string.Empty);

            foreach (var item in produtos)
            {
                (resultadoValidacao, msgValidacao) = item.ValidarCampos(item);
                Assert.True(resultadoValidacao);
            }

            var resultado = _produtoService.DeleteProduto(produtoEsperadoExclusao.Id);
            var resultadoBusca = _produtoService.ObterTodos();

            Assert.DoesNotContain(produtoEsperadoExclusao, resultadoBusca);
            Assert.Equal(1, resultado);
        }
    }
}

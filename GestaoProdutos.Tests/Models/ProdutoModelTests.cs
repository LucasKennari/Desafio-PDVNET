using Bogus;
using GestaoProdutos.Data.Model;

namespace GestaoProdutos.Tests.Model
{
    public class ProdutoModelTests
    {
        private readonly Faker _faker = new("pt_BR");
        [Trait("Produto", "Faker - Bogus")]
        [Fact(DisplayName = "Dado todos os parametros do produto cadastrar")]
        public void DadoTodosOsParametrosDoProdutoCadastrar()
        {
            {
                //Dado todos os parametros
                const int resultadoEsperado = 1;
                var idEsperado = 9999;
                var NomeEsperado = _faker.Commerce.Product();
                var descricaoEsperado = _faker.Commerce.ProductDescription();
                var quantidadeEsperado = _faker.Random.Number(1000000000);
                var precoEsperado = decimal.Parse(_faker.Commerce.Price(-1, 10000, 2));
                var produto = new Produto(idEsperado, NomeEsperado, descricaoEsperado, quantidadeEsperado, precoEsperado);

                Assert.Equal(idEsperado, produto.Id);
                Assert.Equal(NomeEsperado, produto.Nome);
                Assert.Equal(descricaoEsperado, produto.Descricao);
                Assert.Equal(quantidadeEsperado, produto.Quantidade);
                Assert.Equal(precoEsperado, produto.Preco);
            }
        }

        [Trait("Produto", "Sem parametro de construtor")]
        [Fact(DisplayName = "Dado nenhum parametro do produto cadastrar")]
        public void DadoNenhumParametroDoProdutoCadastrar()
        {
            //Dado nenhum parametro
            var idEsperado = 0;
            var nomeEsperado = "";
            var descricaoEsperado = "";
            var quantidadeEsperado = 0;
            var precoEsperado = 0.0m;

            var produto = new Produto();

            Assert.Equal(idEsperado, produto.Id);
            Assert.Equal(nomeEsperado, produto.Nome);
            Assert.Equal(descricaoEsperado, produto.Descricao);
            Assert.Equal(quantidadeEsperado, produto.Quantidade);
            Assert.Equal(precoEsperado, produto.Preco);

        }
    }
}
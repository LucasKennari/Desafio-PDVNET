using GestaoProdutos.Data.Model;
using Microsoft.EntityFrameworkCore.Design;
namespace GestaoProdutos.Data.ProdutoRepository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ProdutoContext _produtoContext;
        public ProdutoRepository(ProdutoContext produtoContext)
        {
            _produtoContext = produtoContext;
        }

        public List<Produto> GetAll()
        {
            return _produtoContext.Produtos.ToList();
        }

        public int AddProduto(Produto produto)
        {
            _produtoContext.Produtos.Add(produto);
            return _produtoContext.SaveChanges(); ;
        }

        public int DeleteProduto(int idProduto)
        {
            var produto = _produtoContext.Produtos.Find(idProduto);
            if (produto != null)
            {
                _produtoContext.Remove(produto);
                return _produtoContext.SaveChanges();
            }
            return 0;
        }
        public int Atualizar(Produto produto)
        {//refact
            if (produto.Id == null)
            {
                return -1;
            }
            var produtoresult = _produtoContext.Produtos.Find(produto.Id);
            if (produto != null)
            {
                produtoresult.Nome = produto.Nome;
                produtoresult.Descricao = produto.Descricao;
                produtoresult.Preco = produto.Preco;
                produtoresult.Quantidade = produto.Quantidade;

                return _produtoContext.SaveChanges();
            }
            return 0;
        }
        public int BuscarPorId(int idProduto)
        {
            var produto = _produtoContext.Produtos.Find(idProduto);
            if (produto == null)
                return -1;

            return produto.Id;
        }
    }
}

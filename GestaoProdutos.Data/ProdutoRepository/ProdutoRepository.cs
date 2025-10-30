using GestaoProdutos.Data.Model;
using Microsoft.EntityFrameworkCore.Design;
namespace GestaoProdutos.Data.ProdutoRepository
{
    public class ProdutoRepository
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
                _produtoContext.Remove(idProduto);
                _produtoContext.SaveChanges();
                return _produtoContext.SaveChanges();
            }
            return 0;
        }
        public int Atualizar(Produto produto)
        {
            _produtoContext.Update(produto);
            return _produtoContext.SaveChanges();
        }
    }
}

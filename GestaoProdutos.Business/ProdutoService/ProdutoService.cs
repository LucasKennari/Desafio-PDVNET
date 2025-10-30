
using GestaoProdutos.Data;
using GestaoProdutos.Data.Model;
using GestaoProdutos.Data.ProdutoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProdutos.Business.ProdutoService
{
    public class ProdutoService
    {
        private readonly ProdutoRepository _produtoRepository;
        public ProdutoService(ProdutoRepository produtoRepository)
        {
           _produtoRepository = produtoRepository;
        }
        public List<Produto> ObterTodos()
        {
            return _produtoRepository.GetAll();
        }

        public int AddProduto(Produto produto)
        {
          if(produto.Preco <= 0)
            {
                throw new Exception("Não é possível adicionar produto sem preço");
            }
          return _produtoRepository.AddProduto(produto);
        }

        public int DeleteProduto(int id)
        {
            return _produtoRepository.DeleteProduto(id);
        }
        public int Atualizar(Produto produto)
        {
           return _produtoRepository.Atualizar(produto);
        }
    }
}

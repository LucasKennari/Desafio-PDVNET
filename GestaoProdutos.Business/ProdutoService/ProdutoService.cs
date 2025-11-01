
using GestaoProdutos.Business.Model;
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
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public List<Produto> ObterTodos()
        {
            return _produtoRepository.GetAll();
        }
        public int TotalProdutosPorQtd() => _produtoRepository.GetAll().Select(x => x.Quantidade).Sum();
        public decimal ValorTotalEstoque() => _produtoRepository.GetAll().Select(x => x.Preco * x.Quantidade).Sum();
        public (int resultado, string mensagem) AddProduto(Produto produto)
        {
            if (produto.Preco <= 0)
            {
                throw new Exception("Não é possível adicionar produto sem preço");

            }
            if (produto.Quantidade <= 0)
            {
                throw new Exception("Não é possível adicionar produto sem quantidade");
            }

            var resultado = _produtoRepository.AddProduto(produto);
            return (resultado, "Adicionado com sucesso");
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

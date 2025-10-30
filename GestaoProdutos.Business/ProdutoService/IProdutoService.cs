using GestaoProdutos.Business.Model;

namespace GestaoProdutos.Business.ProdutoService
{
    public interface IProdutoService
    {
        List<Produto> ObterTodos();
    }
}
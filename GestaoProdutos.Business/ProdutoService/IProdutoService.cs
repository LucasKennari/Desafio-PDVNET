using GestaoProdutos.Data.Model;

namespace GestaoProdutos.Business.ProdutoService
{
    public interface IProdutoService
    {
        (int resultado, string mensagem) AddProduto(Produto produto);
        int Atualizar(Produto produto);
        int DeleteProduto(int id);
        List<Produto> ObterTodos();
        int TotalProdutosPorQtd();
        decimal ValorTotalEstoque();
    }
}
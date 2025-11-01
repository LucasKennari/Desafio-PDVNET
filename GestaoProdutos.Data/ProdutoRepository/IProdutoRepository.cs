using GestaoProdutos.Data.Model;

namespace GestaoProdutos.Data.ProdutoRepository
{
    public interface IProdutoRepository
    {
        int AddProduto(Produto produto);
        int Atualizar(Produto produto);
        int BuscarPorId(int idProduto);
        int DeleteProduto(int idProduto);
        List<Produto> GetAll();
    }
}
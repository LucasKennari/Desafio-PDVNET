using GestaoProdutos.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProdutos.UI.Services
{
    public interface INavigationService
    {
        void AbrirProdutoForm(Action onProdutosQtd, Action onValorTotalEsToque, Action onItensComBaixa);
        void AbrirProdutoFormAdd(Action onProdutoAdicionado = null);
        void AbrirProdutoFormEdit(Produto produto, Action onProdutoEditado = null);
    }
}

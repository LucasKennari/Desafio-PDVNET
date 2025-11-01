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
        void AbrirProdutoForm();
        void AbrirProdutoFormAdd();
        void AbrirProdutoFormEdit(Produto produto);
    }
}

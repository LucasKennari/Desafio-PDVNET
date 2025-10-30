using GestaoProdutos.Data;
using GestaoProdutos.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProdutos.UI.ViewModels
{
    public class MainViewModel
    {
        ProdutoContext _produtoContext;
        Produto NovoProduto = new Produto();
        Produto SelectedProduto = new Produto();
        public MainViewModel(ProdutoContext produtoContext)
        {
            this._produtoContext = produtoContext;
           // GetProdutos();

        }

        private void GetProdutos()
        {
             
        }
    }
}

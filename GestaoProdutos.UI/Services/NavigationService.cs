using GestaoProdutos.Data.Model;
using GestaoProdutos.UI.ViewModels;
using GestaoProdutos.UI.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProdutos.UI.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IServiceProvider _serviceProvider;
        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public void AbrirProdutoForm(Action onProdutosQtd, Action onValorTotalEstoque, Action onItensComBaixa)
        {
            var produtoFormView = _serviceProvider.GetRequiredService<Views.ProdutoFormView>();
            if (produtoFormView.DataContext is ProdutoFormViewModel vm)
            {
                vm.OnProdutosQtd = onProdutosQtd;
                vm.OnItensComBaixa = onItensComBaixa;
                vm.OnValorTotalEstoque = onValorTotalEstoque;
            }
            produtoFormView.ShowDialog();
        }

        public void AbrirProdutoFormAdd(Action onProdutoAdicionado = null)
        {
            var produtoFormAddView = _serviceProvider.GetRequiredService<ProdutoFormAdd>();
            if (produtoFormAddView.DataContext is ProdutoFormAddViewModel vm)
            {
                vm.OnProdutoAdd = onProdutoAdicionado;
            }
            produtoFormAddView.ShowDialog();
        }
        public void AbrirProdutoFormEdit(Produto produto, Action onProdutoEditado = null)
        {
            var vm = _serviceProvider.GetRequiredService<ProdutoFormAddViewModel>();
            vm.SetProduto(produto);
            var produtoFormAddView = _serviceProvider.GetRequiredService<ProdutoFormAdd>();
            vm.OnProdutoAdd = onProdutoEditado;
            produtoFormAddView.DataContext = vm;
            produtoFormAddView.ShowDialog();
        }
    }
}

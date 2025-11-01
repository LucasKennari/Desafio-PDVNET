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
        public void AbrirProdutoForm()
        {
            var produtoFormView = _serviceProvider.GetRequiredService<Views.ProdutoFormView>();
            produtoFormView.ShowDialog();
        }

        public void AbrirProdutoFormAdd()
        {
            var produtoFormAddView = _serviceProvider.GetRequiredService<ProdutoFormAdd>();
            produtoFormAddView.ShowDialog();
            if (produtoFormAddView.DialogResult == true)
            {

            }
        }
        public void AbrirProdutoFormEdit(Produto produto)
        {
            var vm = _serviceProvider.GetRequiredService<ProdutoFormAddViewModel>();
            vm.SetProduto(produto);

            var produtoFormAddView = _serviceProvider.GetRequiredService<ProdutoFormAdd>();
            produtoFormAddView.DataContext = vm;
            produtoFormAddView.ShowDialog();
        }
    }
}

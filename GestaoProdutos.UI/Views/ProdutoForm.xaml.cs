using GestaoProdutos.UI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GestaoProdutos.UI.Views
{
    /// <summary>
    /// Lógica interna para ProdutoFormView.xaml
    /// </summary>
    public partial class ProdutoFormView : Window
    {
        private readonly IServiceProvider _serviceProvider;

        public ProdutoFormView(ProdutoFormViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            this.AddHandler(FrameworkElement.ContextMenuOpeningEvent, new ContextMenuEventHandler(OnContextMenuOpening));

        }
        private void OnContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            if (e.Source is FrameworkElement fe && fe.ContextMenu != null)
            {
                fe.ContextMenu.DataContext = fe.DataContext;
            }
        }
    }
}

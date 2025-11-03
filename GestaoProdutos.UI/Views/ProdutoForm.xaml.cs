using GestaoProdutos.UI.ViewModels;
using System.Windows;
using System.Windows.Controls;

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

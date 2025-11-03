using GestaoProdutos.UI.ViewModels;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GestaoProdutos.UI.Views
{
    /// <summary>
    /// Lógica interna para ProdutoFormAdd.xaml
    /// </summary>
    public partial class ProdutoFormAdd : Window
    {
        public ProdutoFormAdd(ProdutoFormAddViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;

        }

    }
}

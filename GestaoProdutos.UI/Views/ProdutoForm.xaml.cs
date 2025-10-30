using GestaoProdutos.UI.ViewModels;
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
        public ProdutoFormView(ProdutoFormViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void btnCarregar_Click(object sender, RoutedEventArgs e)
        {
         
        }
    }
}

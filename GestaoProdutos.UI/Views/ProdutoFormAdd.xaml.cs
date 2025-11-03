using GestaoProdutos.Data.Model;
using GestaoProdutos.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Lógica interna para ProdutoFormAdd.xaml
    /// </summary>
    public partial class ProdutoFormAdd : Window
    {
        public ProdutoFormAdd(ProdutoFormAddViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;

        }

        private void txtPreco_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"[0-9]");
        }

        private void txtPreco_TextChanged(object sender, TextChangedEventArgs e)
        {
            var txt = sender as TextBox;

            if (decimal.TryParse(txt.Text.Replace("R$", "").Replace(",", "").Replace(".", ""),
                                 out decimal valor))
            {
                txt.TextChanged -= txtPreco_TextChanged;
                txt.Text = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", valor / 100);
                txt.CaretIndex = txt.Text.Length;
                txt.TextChanged += txtPreco_TextChanged;
            }
        }

    }
}

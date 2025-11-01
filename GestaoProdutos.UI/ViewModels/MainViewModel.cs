using GalaSoft.MvvmLight.Command;
using GestaoProdutos.Business.Model;
using GestaoProdutos.Business.ProdutoService;
using GestaoProdutos.Data.Model;
using GestaoProdutos.UI.Command;
using GestaoProdutos.UI.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Input;
using Produto = GestaoProdutos.Data.Model.Produto;

namespace GestaoProdutos.UI.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IProdutoService _produtoService;
        private readonly INavigationService _navigationService;
        public ICommand AbrirProdutoFormCommand { get; }
        //private List<Produto> _produtoBaixa { get; set; }
        //private List<Produto> _produtoPorCat { get; set; }
        public ObservableCollection<Produto> ProdutoBaixa { get; set; } = new ObservableCollection<Produto>();


        private int _totalProdutosQtd;
        public int TotalProdutosQtd
        {
            get => _totalProdutosQtd;
            set
            {
                _totalProdutosQtd = value;
                OnPropertyChanged(nameof(TotalProdutosQtd));
                OnPropertyChanged(CorEstoque("", TotalProdutosQtd));
            }
        }
        private string _vlrTotalEstoque;
        public string VlrTotalEstoque
        {
            get => _vlrTotalEstoque;
            set
            {
                _vlrTotalEstoque = value;
                OnPropertyChanged(nameof(VlrTotalEstoque));
                OnPropertyChanged(CorEstoque(VlrTotalEstoque, 0));
            }
        }

        //public List<Produto> ProdutoBaixa
        //{
        //    get => _produtoBaixa; private set
        //    {
        //        _produtoBaixa = value;
        //        OnPropertyChanged(nameof(ProdutoBaixa));
        //    }
        //}


        public string CorEstoque(string? valor, int? quantidade)
        {
            //var tipo = valor > 0 ? valor : quantidade;
            //if (tipo < 50)
            //    return "Red";
            //if (tipo < 150)
            //    return "Orange";
            return "Green";
        }
        public event PropertyChangedEventHandler PropertyChanged;

        //Produto NovoProduto = new Produto();
        //Produto SelectedProduto = new Produto();
        public MainViewModel(IProdutoService produtoService, INavigationService navigationService)
        {
            _navigationService = navigationService;
            _produtoService = produtoService;
            ProdutoBaixa = new ObservableCollection<Produto>();
            AbrirProdutoFormCommand = new BaseCommand(btnAbrirProdutoForm, PodeExecutar);
            CarregaProdutosPorQtd();
            CarregaValorTotalEstoque();
            CarregaItensComBaixa();
        }
        public void btnAbrirProdutoForm() => _navigationService.AbrirProdutoForm();
        public bool PodeExecutar() => true;
        public void CarregaProdutosPorQtd() => TotalProdutosQtd = _produtoService.TotalProdutosPorQtd();
        public void CarregaValorTotalEstoque()
        {
            decimal valorTotal = 0;
            var vlrProduto = _produtoService.ValorTotalEstoque();
            VlrTotalEstoque = vlrProduto.ToString("C", new CultureInfo("pt-BR")); ;
            //testar com o retorno 0
        }

        public void CarregaItensComBaixa()
        {
            List<Produto> produtos = _produtoService.ObterTodos().Where(p => p.Quantidade <= 5)
                .OrderBy(p => p.Quantidade)
                .ToList();
            

            foreach (var produto in produtos)
            {
                ProdutoBaixa.Add(produto);
            }
        }
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}

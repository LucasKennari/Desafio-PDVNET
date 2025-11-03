using GalaSoft.MvvmLight.Command;
using GestaoProdutos.Business.ProdutoService;
using GestaoProdutos.Data.Model;
using GestaoProdutos.UI.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace GestaoProdutos.UI.ViewModels
{
    public class ProdutoFormViewModel : INotifyPropertyChanged
    {
        private readonly IProdutoService _produtoService;
        private readonly INavigationService _navigationService;
        public ICommand CarregarProdutoCommand { get; }
        public ICommand AdicionarProdutoFromCommand { get; }
        public ICommand EditarProdutoFromCommand { get; }
        public ICommand ExcluirProdutoFromCommand { get; }
        public ICommand ClickBtnSairCommand { get; set; }

        public Action OnProdutosQtd { get; set; }
        public Action OnValorTotalEstoque { get; set; }
        public Action OnItensComBaixa { get; set; }

        public ObservableCollection<Produto> Produtos { get; set; } = new ObservableCollection<Produto>();

        public event PropertyChangedEventHandler? PropertyChanged;
        private Produto _produtoSelecionado;
        public Produto ProdutoSelecionado
        {
            get => _produtoSelecionado;
            set { _produtoSelecionado = value; OnPropertyChanged(nameof(ProdutoSelecionado)); }
        }
        public ProdutoFormViewModel(IProdutoService produtoService, INavigationService navigationService)
        {
            _produtoService = produtoService;
            _navigationService = navigationService;
            Produtos = new ObservableCollection<Produto>();
            CarregarProdutoCommand = new RelayCommand(CarregarProdutos);
            AdicionarProdutoFromCommand = new RelayCommand(AbrirProdutoFormAdd);
            EditarProdutoFromCommand = new RelayCommand(AbrirProdutoFormEdit);
            ExcluirProdutoFromCommand = new RelayCommand(ExluirProdutoFormEdit);
            ClickBtnSairCommand = new RelayCommand(FecharJanela);
        }

        private void CarregarProdutos()
        {
            var lista = _produtoService.ObterTodos();
            Produtos.Clear();
            Produtos = new ObservableCollection<Produto>(lista);
            OnPropertyChanged(nameof(Produtos));
        }
        private void AbrirProdutoFormAdd() => _navigationService.AbrirProdutoFormAdd(CarregarProdutos);
        private void AbrirProdutoFormEdit()
        {
            if (_produtoSelecionado?.Id == null)
            {
                return;
            }
            _navigationService.AbrirProdutoFormEdit(_produtoSelecionado, CarregarProdutos);
        }
        private void ExluirProdutoFormEdit()
        {
            if (_produtoSelecionado?.Id == null)
            {
                return;
            }
           var result =  _produtoService.DeleteProduto(_produtoSelecionado.Id);
            if (result == 0)
            {
                System.Windows.MessageBox.Show("Erro ao excluir produto.");
                return;
            }
            System.Windows.MessageBox.Show("Produto excluido com sucesso!");
            CarregarProdutos();
        }
        public void FecharJanela()
        {
            foreach (Window win in Application.Current.Windows)
            {
                if (win.DataContext == this)
                {
                    win.Close();
                    break;
                }
            }
            OnProdutosQtd?.Invoke();
            OnItensComBaixa?.Invoke();
            OnValorTotalEstoque?.Invoke();
        }
        protected void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

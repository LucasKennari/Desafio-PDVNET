using GalaSoft.MvvmLight.Command;
using GestaoProdutos.Business.ProdutoService;
using GestaoProdutos.Data.Model;
using GestaoProdutos.UI.Command;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace GestaoProdutos.UI.ViewModels
{
    public class ProdutoFormAddViewModel : INotifyPropertyChanged
    {
        private readonly IProdutoService _produtoService;
        public Action OnProdutoAdd { get; set; }
        private int _Id;
        public int Id
        {
            get => _Id;
            set { _Id = value; OnPropertyChanged(nameof(Id)); }
        }
        private string _nome;
        public string Nome
        {
            get => _nome;
            set { _nome = value; OnPropertyChanged(nameof(Nome)); }
        }

        private string _descricao;
        public string Descricao
        {
            get => _descricao;
            set { _descricao = value; OnPropertyChanged(nameof(Descricao)); }
        }

        private int _quant;
        public int Quant
        {
            get => _quant;
            set
            {
                _quant = value;
                OnPropertyChanged(nameof(Quant));
            }
        }

        private decimal _preco;
        public decimal Preco
        {
            get => _preco;
            set { _preco = value; OnPropertyChanged(nameof(Preco)); }
        }
        private Produto _produto { get; set; }
        public ICommand AdicionarProdutoCommand { get; }
        public ICommand EditarProdutoCommand { get; }
        public ICommand OkProdutoCommand { get; set; }
        public ICommand ClickBtnSairCommand { get; set; }
        public ICommand OnlyNumbersCommand { get; set; }
        string mensagem = string.Empty;
        public ProdutoFormAddViewModel(IProdutoService produtoService)
        {
            _produtoService = produtoService;
            AdicionarProdutoCommand = new RelayCommand(AdicionarProduto);
            EditarProdutoCommand = new RelayCommand(EditarProduto);
            OkProdutoCommand = new RelayCommand(AdicionarProduto);
            ClickBtnSairCommand = new RelayCommand(SairProduto);
            OnlyNumbersCommand = new BaseCommand(OnlyNumbersTextChanged, PodeExecutar);

        }

        private void SairProduto()
        {
            FecharJanela();
        }
        private bool PodeExecutar()
        {
            return true;
        }
        internal void SetProduto(Produto produto)
        {
            _produto = produto;
            if (produto?.Id != null)
            {
                OkProdutoCommand = new RelayCommand(EditarProduto);
                CarregarCampos();
                return;
            }
        }
        private void CarregarCampos()
        {
            if (_produto?.Nome == null)
                return;
            Nome = _produto.Nome;
            Descricao = _produto.Descricao;
            Preco = _produto.Preco;
            Quant = _produto.Quantidade;
        }
        public void EditarProduto()
        {
            if (!ValidaCampos())
            {
                System.Windows.MessageBox.Show(mensagem);
                return;
            }
            var result = _produtoService.Atualizar(new Produto
            {
                Id = _produto.Id,
                Nome = this.Nome,
                Descricao = this.Descricao,
                Quantidade = this.Quant,
                Preco = this.Preco
            });
            if (result == 0)
            {
                System.Windows.MessageBox.Show("Erro ao Editar produto.");
                return;
            }
            System.Windows.MessageBox.Show("Produto Editado com sucesso!");
            OnProdutoAdd?.Invoke();
            FecharJanela();
        }
        public void AdicionarProduto()
        {
            if (!ValidaCampos())
            {
                System.Windows.MessageBox.Show(mensagem);
                return;
            };
            var result = _produtoService.AddProduto(new Produto()
            {
                Nome = this.Nome,
                Descricao = this.Descricao,
                Quantidade = this.Quant,
                Preco = this.Preco
            });
            if (result.resultado == 0)
            {
                System.Windows.MessageBox.Show("Erro ao adicionar produto.");
                return;
            }
            System.Windows.MessageBox.Show("Produto Adicionado com sucesso!");
            OnProdutoAdd?.Invoke();
            FecharJanela();
        }


        private bool ValidaCampos()
        {
            mensagem = string.Empty;
            if (string.IsNullOrEmpty(Nome))
            {
                mensagem = "Nome do produto é obrigatório";
                return false;

            }
            else if (Quant <= 0 || string.IsNullOrEmpty(Quant.ToString()))
            {
                mensagem = "Quantidade é obrigatório";
                return false;
            }
            else if (string.IsNullOrEmpty(Preco.ToString()) || Preco <= 0)
            {
                mensagem = "Preço é obrigatório";
                return false;

            }
            else
            {
                return true;
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void OnlyNumbersTextChanged()
        {
            var isNumberQuant = new Regex("[^0-9]+").IsMatch(Quant.ToString());
            if (!isNumberQuant)
                return;
            var isNumberPreco = new Regex("[^0-9]+").IsMatch(Quant.ToString());
            if (!isNumberPreco)
                return;
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
        }
    }
}

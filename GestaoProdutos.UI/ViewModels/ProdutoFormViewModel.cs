using GalaSoft.MvvmLight.Command;
using GestaoProdutos.Business.ProdutoService;
using GestaoProdutos.Data.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GestaoProdutos.UI.ViewModels
{
    public class ProdutoFormViewModel
    {
        private readonly ProdutoService _produtoService;
        public ProdutoFormViewModel(ProdutoService produtoService)
        {
            _produtoService = produtoService;
            Produtos = new ObservableCollection<Produto>();
            CarregarProdutoCommand = new RelayCommand(CarregarProdutos);
           // CarregarProdutos();
        }
        public ICommand CarregarProdutoCommand { get; }
        public ObservableCollection<Produto> Produtos { get; set; } = new ObservableCollection<Produto>();
        private Produto _produtoSelecionado;
        public Produto ProdutoSelecionado
        {
            get => _produtoSelecionado;
            //set => setPrO(ref _produtoSelecionado, value);
        }

        private void CarregarProdutos()
        {
            var lista = _produtoService.ObterTodos();
            Produtos.Clear();

            foreach (var produto in lista)
            {
                Produtos.Add(produto);
            }
        }
    }
}

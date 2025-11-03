using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;

namespace GestaoProdutos.Data.Model
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = 0;
        public string? Nome { get; set; } = "";
        public string? Descricao { get; set; } = "";
        public decimal Preco { get; set; } = 0.0m;
        public int Quantidade { get; set; } = 0;
        public DateTime DataCadastro { get; set; }
        public int Categoria { get; set; }
        public Produto()
        {

        }
        public Produto(int id, string nome, string descricao, int quantidade, decimal preco )
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Quantidade = quantidade;
            Preco = preco;
        }
        public (bool resultado, string msg) ValidarCampos(Produto produto)
        {
            if (string.IsNullOrEmpty(produto.Nome))
            {
                return (false, "Nome do produto é obrigatório");
            }
            else if (produto.Quantidade <= 0 || string.IsNullOrEmpty(produto.Quantidade.ToString()))
            {
                return (false, "Quantidade é obrigatório");
            }
            else if (string.IsNullOrEmpty(produto.Preco.ToString()) || produto.Preco <= 0)
            {
                return (false, "Preço é obrigatório");
            }
            else
            {
                return (true, "Produto validado com sucesso.");
            }

        }
    }
}
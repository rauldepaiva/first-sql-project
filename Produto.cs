using System;

namespace CADProdutos
{
    public class Produto
    {
        public int Id {get; set;}
        public string Nome {get; set;}
        public decimal Preco {get; set;}
        public bool Disponivel {get; set;}
        public DateTime DataCadastro {get; set;}

        public Produto()
        {
            DataCadastro = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Id: {Id}; Produto: {Nome}; Preço: {Preco}; Disponível: {Disponivel}; Data: {DataCadastro}.";
        }
    }
}
using System;
using System.Collections.Generic;

namespace CADProdutos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cadastrando");
            Console.WriteLine("Digite C para cadastro, L para listagem, A para atualização ou D para deletar:");
            string comando = Console.ReadLine();
            
            ProdutoRepository pr = new ProdutoRepository();
            Produto prod;

            switch(comando.ToUpper())
            {
                case "C":
                    prod = new Produto();
                    Console.WriteLine("Insira o nome:");
                    prod.Nome = Console.ReadLine();
                    Console.WriteLine("Insira o preço:");
                    prod.Preco = decimal.Parse(Console.ReadLine());
                    pr.Insert(prod);
                    break;

                case "L":
                    List<Produto> lista = pr.Query();
                    foreach (Produto item in lista)
                    {
                        Console.WriteLine(item.ToString());
                    }
                    break;
                case "A":
                    prod = new Produto();
                    Console.Write("Digite o id do produto que será atualizado: ");
                    prod.Id = int.Parse(Console.ReadLine());

                    Console.Write("Digite o novo nome do produto: ");
                    prod.Nome = Console.ReadLine();

                    Console.Write("Digite o novo preco do produto: ");
                    prod.Preco = Decimal.Parse(Console.ReadLine());

                    Console.Write("O produto está disponível [s/n]: ");
                    prod.Disponivel = (Console.ReadLine().ToLower() == "s");

                    pr.Update(prod);
                    break;

                case "D":
                    string confirma;
                    prod = new Produto();

                    Console.Write("Digite o id do produto a ser deletado: ");
                    prod.Id = int.Parse(Console.ReadLine());

                    Console.Write("Essa operação não pode ser desfeita. Aperte S para continuar ou qualquer outra tecla para cancelar.");
                    confirma = Console.ReadLine();

                    if (confirma.ToUpper() == "S")
                    {
                        pr.Delete(prod);
                        Console.Write("Produto deletado.");
                    }
                    else
                    {
                        Console.Write("Nenhuma informação foi deletada.");
                    }
                    
                    break;

                default:
                    Console.WriteLine("Comando inválido");
                    break;
            }
        }
    }
}

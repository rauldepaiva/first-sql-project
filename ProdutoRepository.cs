using System;
using MySqlConnector;
using System.Collections.Generic;

namespace CADProdutos
{
    public class ProdutoRepository
    {
        private const string enderecoConexao = "Database=admprodutos; Data Source=localhost; User Id=root;";

        public void Insert(Produto produto)
        {
            MySqlConnection conexao = new MySqlConnection(enderecoConexao);
            conexao.Open();

            string sqlInsert = 
            "INSERT INTO produto (nome, preco, disponivel, dataCadastro)" +
            "VALUES ('" + produto.Nome + "'," + produto.Preco + "," + produto.Disponivel + ", NOW())";            
            MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);
            comando.ExecuteNonQuery();

            conexao.Close();
        }

        public List<Produto> Query()
        {
            MySqlConnection conexao = new MySqlConnection(enderecoConexao);
            conexao.Open();

            string sqlSelect = "SELECT * FROM produto";
            MySqlCommand comandoQuery = new MySqlCommand(sqlSelect, conexao);
            MySqlDataReader resultado = comandoQuery.ExecuteReader();

            List<Produto> listaProdutos = new List<Produto>();

            while(resultado.Read())
            {
                Produto item = new Produto();
                item.Id = resultado.GetInt32("id");
                item.Nome = resultado.GetString("nome");
                item.Preco = resultado.GetDecimal("preco");
                item.Disponivel = resultado.GetBoolean("disponivel");
                item.DataCadastro = resultado.GetDateTime("dataCadastro");

                listaProdutos.Add(item);
            }

            resultado.Close();
            conexao.Close();

            return listaProdutos;
        }

        public void Update(Produto p)
        {
            MySqlConnection conexao = new MySqlConnection(enderecoConexao);
            conexao.Open();

            string sqlUpdate =
            "UPDATE produto " +
            " SET nome = '" + p.Nome +
            "', preco = " + p.Preco.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) +
            ", " + "disponivel = " + (p.Disponivel ? 1 : 0) + 
            " WHERE id=" + p.Id;

            MySqlCommand comando = new MySqlCommand(sqlUpdate, conexao);
            comando.ExecuteNonQuery();

            conexao.Close();
        }

        public void Delete(Produto p)
        {
            MySqlConnection conexao = new MySqlConnection(enderecoConexao);
            conexao.Open();

            string sqlDelete = $"DELETE FROM produto WHERE id={p.Id}";

            MySqlCommand comando = new MySqlCommand(sqlDelete, conexao);
            comando.ExecuteNonQuery();

            conexao.Close();
        }
    }
}
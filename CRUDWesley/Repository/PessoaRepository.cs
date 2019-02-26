using CRUDWesley.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUDWesley.Repository
{
    public class PessoaRepository
    {
        private SqlConnection conn;

        private void ConectarSql()
        {
            Conexao con = new Conexao();
            conn = con.ConectarSql(ref conn);
        }

        //adicionar uma Pessoa
        public void Adicionar(Pessoa pessoa)
        {
            ConectarSql();

            string comando = "INSERT INTO Pessoa (nome, endereco, email)" +
                                   "values(@nome, @endereco, @email)";

            SqlCommand cmd = new SqlCommand(comando, conn);

            cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = pessoa.Nome;
            cmd.Parameters.Add("@endereco", SqlDbType.VarChar).Value = pessoa.Endereco;
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = pessoa.Email;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<Pessoa> BuscarTodos()
        {
            List<Pessoa> listaPessoas = new List<Pessoa>();
            ConectarSql();

            string comando = "select * from Pessoa";
            SqlCommand cmd = new SqlCommand(comando, conn);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Pessoa pessoa = new Pessoa()
                {
                    Codigo = Convert.ToInt32(reader["Codigo"]),
                    Nome = Convert.ToString(reader["Nome"]),
                    Endereco = Convert.ToString(reader["Endereco"]),
                    Email = Convert.ToString(reader["Email"])
                };

                listaPessoas.Add(pessoa);
            }

            return listaPessoas;
        }


        public void Excluir(string id)
        {
        }

        internal void Alterar(Pessoa pessoa)
        {
            ConectarSql();

            string comando = "UPDATE Pessoa set nome = @nome, endereco = @endereco, email = @email " +
                                "WHERE codigo = @codigo";

            SqlCommand cmd = new SqlCommand(comando, conn);

            cmd.Parameters.Add("@codigo", SqlDbType.Int).Value = pessoa.Codigo;
            cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = pessoa.Nome;
            cmd.Parameters.Add("@endereco", SqlDbType.VarChar).Value = pessoa.Endereco;
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = pessoa.Email;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        internal void Deletar(int id)
        {
            ConectarSql();
            string query = "DELETE FROM Pessoa WHERE codigo = @codigo";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@codigo", SqlDbType.Int).Value = id;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                
                throw;
            }
        }
    }
}
using Heimdall.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Heimdall.DataObjects
{
    public class UsuarioDO : DataObject<Usuario>
    {

        public bool Inserir(Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(
                WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                connection.Open();

                string sql = ($"INSERT INTO[dbo].[Usuario]([NomeCompleto],[Email],[Cargo],[Senha])VALUES " +
                   $"('{usuario.nomeCompleto}'," +
                   $"'{usuario.email}'," +
                   $"'{usuario.cargo}'," +
                   $"'{usuario.senha}')");

                SqlCommand command = new SqlCommand(sql, connection);

                if (command.ExecuteNonQuery() != 0)
                {
                    connection.Close();
                    return true;
                }
                else
                {
                    connection.Close();
                    return false;
                }

            }
        }

        void DataObject<Usuario>.Deletar(Usuario obj)
        {
            throw new NotImplementedException();
        }

        void DataObject<Usuario>.Update(Usuario usuario)
        {

            using (SqlConnection connection = new SqlConnection(
                WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                connection.Open();

                string sql = ($"UPDATE [dbo].[Usuario] SET " +
                $"[NomeCompleto] = '{usuario.nomeCompleto}'," +
                $"[Email] = '{usuario.email}'," +
                $"[Cargo] = '{usuario.cargo}'," +
                $"[Senha] = '{usuario.senha}'" +
                $"WHERE [CodUsuario] = {usuario.codUsuario}");

                SqlCommand command = new SqlCommand(sql, connection);

                command.ExecuteNonQuery();           
        }
    }


    public Usuario buscar(Usuario usuario)
    {
        using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
        {

            connection.Open();

            string sql = ($"SELECT TOP(1) [CodUsuario],[NomeCompleto],[Email],[Cargo],[Senha],[Ativo],[DataCadastro] FROM[dbo].[Usuario]" +
                            $"WHERE Email = '{usuario.email}' " +
                            $"AND Senha = '{usuario.senha}'");

            SqlCommand command = new SqlCommand(sql, connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    usuario.codUsuario = int.Parse(reader["CodUsuario"].ToString());
                    usuario.nomeCompleto = reader["NomeCompleto"].ToString();
                    usuario.email = reader["Email"].ToString();
                    usuario.cargo = reader["Cargo"].ToString();
                    usuario.senha = reader["senha"].ToString();
                    usuario.ativo = bool.Parse(reader["Ativo"].ToString());
                    usuario.dataCadastro = DateTime.Parse(reader["DataCadastro"].ToString());
                }
                reader.Close();
            }
            return usuario;
        }
    }

    public List<Usuario> Selecionar()
    {
        using (SqlConnection connection = new SqlConnection(
        WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
        {
            List<Usuario> usuarios = new List<Usuario>();
            connection.Open();

            string sql = ($"SELECT [CodUsuario],[NomeCompleto],[Email],[Cargo],[Senha],[Ativo],[DataCadastro] FROM[dbo].[Usuario]");

            SqlCommand command = new SqlCommand(sql, connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {

                // Call Read before accessing data.
                while (reader.Read())
                {
                    Usuario usuario = new Usuario();

                    usuario.codUsuario = int.Parse(reader["CodUsuario"].ToString());
                    usuario.nomeCompleto = reader["NomeCompleto"].ToString();
                    usuario.email = reader["Email"].ToString();
                    usuario.senha = reader["Cargo"].ToString();
                    usuario.ativo = bool.Parse(reader["Ativo"].ToString());
                    usuario.dataCadastro = DateTime.Parse(reader["DataCadastro"].ToString());

                    usuarios.Add(usuario);
                }

                reader.Close();

            }

            return usuarios;

        }
    }

    public Usuario buscar(Usuario obj, int cod)
    {
        throw new NotImplementedException();
    }
}
}
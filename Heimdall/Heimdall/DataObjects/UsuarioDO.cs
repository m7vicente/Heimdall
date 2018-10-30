using Heimdall.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Heimdall.DataObjects
{
    public class UsuarioDO : IDisposable
    {
        public void Dispose()
        {
            Dispose();
        }

        public bool inserir(Usuario usuario) 
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
    }
}
using Heimdall.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Heimdall.DataObjects
{
    public class SistemaOperacionalDO : DataObject<SistemaOperacional>
    {
        public SistemaOperacional buscar(SistemaOperacional obj)
        {
            throw new NotImplementedException();
        }

        public void Deletar(SistemaOperacional obj)
        {
            throw new NotImplementedException();
        }

        public bool Inserir(SistemaOperacional obj)
        {
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                connection.Open();

                string sql = ("INSERT INTO [dbo].[SistemaOperacional] ([NomeFrabricante],[NomeVersao],[Familia],[FKCodComputador],[FKCodUsuario]) VALUES " +
                           $"('{obj.fabricanteSO}'" +
                           $",'{obj.versaoSO}'" +
                           $",'{obj.familiaSO}'" +
                           $",'{obj.codComputador}'" +
                           $",'{obj.codUsuario}')");

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

        public List<SistemaOperacional> Selecionar()
        {
            throw new NotImplementedException();
        }

        public void Update(SistemaOperacional obj)
        {
            throw new NotImplementedException();
        }
    }
}
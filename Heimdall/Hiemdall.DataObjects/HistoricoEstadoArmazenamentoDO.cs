using Heimdall.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Heimdall.DataObjects
{
    public class HistoricoEstadoArmazenamentoDO : DataObject<Armazenamento>
    {
        public Armazenamento buscar(Armazenamento obj)
        {
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {

                connection.Open();

                string sql = ($"SELECT TOP 1 * FROM HistoricoEstadoArmazenamento where FKCodUUId = '{obj.codUUID}' ORDER BY DataEstado DESC");

                SqlCommand command = new SqlCommand(sql, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        obj.capacidadeUtilizada = double.Parse(reader["capacidadeUltilizada"].ToString());
                        obj.letraLocal = reader["LetraLocal"].ToString();
                        obj.dataEstado = DateTime.Parse(reader["dataEstado"].ToString());
                    }
                    reader.Close();
                }
                connection.Close();
                return obj;
            }
        }

        public void Deletar(Armazenamento obj)
        {
            throw new NotImplementedException();
        }

        public bool Inserir(Armazenamento obj)
        {
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {

                connection.Open();

                string sql = ("INSERT INTO [dbo].[HistoricoEstadoArmazenamento] ([CapacidadeUltilizada],[LetraLocal],[FKCodUUId],[FKCodComputador],[FKCodUsuario]) VALUES "+
                                $"('{obj.capacidadeUtilizada.ToString().Replace(",",".")}'" +
                                $",'{obj.letraLocal}'" +
                                $",'{obj.codUUID}'" +
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

        public List<Armazenamento> Selecionar()
        {
            throw new NotImplementedException();
        }

        public void Update(Armazenamento obj)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;
using Heimdall.Models;

namespace Heimdall.DataObjects
{
    public class ProcessadorDO : DataObject<Processador>
    {
        public Processador buscar(Processador obj)
        {
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {

                connection.Open();

                string sql = ($"SELECT TOP (1) [CodProcessador],[NomeFabricante],[Modelo],[FrequenciaBase],[Nucleos],[Serial],[FKCodComputador],[FKCodUsuario] FROM [dbo].[Processador] "+
                              $"WHERE [FKCodComputador] = {obj.codComputador} " +
                              $"AND [FKCodUsuario] = {obj.codUsuario} "+
                              $"OR Serial = '{obj.serial}'");
                               
                SqlCommand command = new SqlCommand(sql, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        obj.codProcessador = int.Parse(reader["CodProcessador"].ToString());
                        obj.nomeFabricante = reader["NomeFabricante"].ToString();
                        obj.modelo = reader["Modelo"].ToString();
                        obj.frequenciaBase = float.Parse(reader["FrequenciaBase"].ToString());
                        obj.nucleos = int.Parse(reader["Nucleos"].ToString());
                        obj.serial = reader["Serial"].ToString();
                        obj.codComputador = int.Parse(reader["FKCodComputador"].ToString());
                        obj.codUsuario = int.Parse(reader["FKCodUsuario"].ToString());
                    }
                    reader.Close();
                }
                return obj;
            }
        }

        public void Deletar(Processador obj)
        {
            throw new NotImplementedException();
        }

        public bool Inserir(Processador obj)
        {
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {

                connection.Open();

                string sql = ($" INSERT INTO[dbo].[Processador]([NomeFabricante],[Modelo],[FrequenciaBase],[Nucleos],[Serial],[FKCodComputador],[FKCodUsuario]) VALUES"+
                               $"('{obj.nomeFabricante}'" +
                               $",'{obj.modelo}'" +
                               $",'{obj.frequenciaBase.ToString().Replace(',','.')}'" +
                               $", {obj.nucleos}" +
                               $",'{obj.serial}'" +
                               $", {obj.codComputador}" +
                               $", {obj.codUsuario})");

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

        public List<Processador> Selecionar()
        {
            throw new NotImplementedException();
        }

        public void Update(Processador obj)
        {
            throw new NotImplementedException();
        }
    }
}
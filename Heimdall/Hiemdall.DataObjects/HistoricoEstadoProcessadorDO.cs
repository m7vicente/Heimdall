using Heimdall.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Heimdall.DataObjects
{
    public class HistoricoEstadoProcessadorDO : DataObject<Processador>
    {
        public Processador buscar(Processador obj)
        {
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {

                connection.Open();

                string sql = ($"SELECT TOP (1) * FROM [dbo].[HistoricoEstadoProcessador] " +
                              $"WHERE FKCodComputador = {obj.codComputador} " +
                              $"ORDER BY DataEstado DESC");

                SqlCommand command = new SqlCommand(sql, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        obj.processosExecucao = long.Parse(reader["ProcessadorExecucao"].ToString());
                        obj.porcentagemUtilizacao = int.Parse(reader["PorcentagemUltlizacao"].ToString());
                        obj.threadsExecucao = int.Parse(reader["ThreadExecucao"].ToString());
                        obj.tempoExecucao = reader["tempoExecucao"].ToString();
                        obj.temperaturaCpu = double.Parse(reader["Temperatura"].ToString());
                        obj.codComputador = int.Parse(reader["FKCodComputador"].ToString());
                        obj.codProcessador = int.Parse(reader["FKCodUsuario"].ToString());
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

                string sql = ($" INSERT INTO[dbo].[HistoricoEstadoProcessador]([ProcessadorExecucao],[PorcentagemUltlizacao],[ThreadExecucao],[TempoExecucao],[Temperatura],[FKCodProcessador],[FKCodComputador],[FKCodUsuario]) VALUES" +
                               $"({obj.processosExecucao}" +
                               $",{obj.porcentagemUtilizacao}" +
                               $",{obj.threadsExecucao}" +
                               $",'{obj.tempoExecucao}'" +
                               $",'{obj.temperaturaCpu.ToString().Replace(",", ".")}'" +
                               $", {obj.codProcessador}" +
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
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

                string sql = ($"SELECT[CodProcessador],[NomeFabricante],[Modelo],[FrequenciaBase],[Nucleos],[Serial],[FKCodComputador],[FKCodUsuario] FROM[dbo].[Processador] " +
                            $"WHERE Serial = '{obj.serial}' " +
                            $"OR (FKCodComputador = {obj.codComputador}," +
                            $"AND FKCodUsuario = {obj.codUsuario})");

                SqlCommand command = new SqlCommand(sql, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        obj.codProcessador = int.Parse(reader["CodProcessador"].ToString());
                        obj.nomeFabricante = reader["FrequenciaBase"].ToString();
                        obj.modelo = reader["modelo"].ToString();
                        obj.nucleos = int.Parse(reader["Nucleos"].ToString());
                        obj.serial = reader["serial"].ToString();
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

                string sql = ($" INSERT INTO[dbo].[HistoricoEstadoProcessador]([ProcessadorExecucao],[PorcentagemUltlizacao],[ThreadExecucao],[TempoExecucao],[Temperatura],[FKCodProcessador],[FKCodComputador],[FKCodUsuario]) VALUES"+
                               $"({obj.processosExecucao}"+
                               $",{obj.porcentagemUtilizacao}"+
                               $",{obj.threadsExecucao}"+
                               $",'{obj.tempoExecucao}'"+
                               $",'{obj.temperaturaCpu.ToString().Replace(",",".")}'"+
                               $", {obj.codProcessador}"+
                               $", {obj.codComputador}"+
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
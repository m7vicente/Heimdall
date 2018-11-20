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

                string sql = ($"SELECT TOP (1) [CodProcessador],[NomeFabricante],[Modelo],[FrequenciaBase],[Nucleos],[Serial],[FKCodComputador],[FKCodUsuario] FROM [dbo].[Processador] " +
                              $"WHERE [FKCodComputador] = {obj.codComputador} " +
                              $"AND [FKCodUsuario] = {obj.codUsuario} " +
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

        public Processador buscar(int codComputador)
        {
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {

                connection.Open();

                string sql = ($"SELECT TOP (1) [CodProcessador],[NomeFabricante],[Modelo],[FrequenciaBase],[Nucleos],[Serial],[FKCodComputador],[FKCodUsuario] FROM [dbo].[Processador] " +
                              $"WHERE [FKCodComputador] = {codComputador}");

                SqlCommand command = new SqlCommand(sql, connection);

                Processador obj = new Processador();

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
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                connection.Open();

                string sql = ($" DELETE FROM Processador " +
                               $"WHERE" +
                               $"FKCodComputador = {obj.codComputador}" +
                               $"AND FKCodUsuario = {obj.codUsuario})");

                SqlCommand command = new SqlCommand(sql, connection);

                connection.Close();
            }
        }

        public bool Inserir(Processador obj)
        {
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {

                connection.Open();

                string sql = ($" INSERT INTO[dbo].[Processador]([NomeFabricante],[Modelo],[FrequenciaBase],[Nucleos],[Serial],[FKCodComputador],[FKCodUsuario]) VALUES" +
                               $"('{obj.nomeFabricante}'" +
                               $",'{obj.modelo}'" +
                               $",'{obj.frequenciaBase.ToString().Replace(',', '.')}'" +
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

            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {

                connection.Open();

                string sql = ($"SELECT [CodProcessador],[NomeFabricante],[Modelo],[FrequenciaBase],[Nucleos],[Serial],[FKCodComputador],[FKCodUsuario] FROM [dbo].[Processador] ");

                List<Processador> processadores = new List<Processador>();

                SqlCommand command = new SqlCommand(sql, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Processador processador = new Processador();
                        processador.codProcessador = int.Parse(reader["CodProcessador"].ToString());
                        processador.nomeFabricante = reader["NomeFabricante"].ToString();
                        processador.modelo = reader["Modelo"].ToString();
                        processador.frequenciaBase = float.Parse(reader["FrequenciaBase"].ToString());
                        processador.nucleos = int.Parse(reader["Nucleos"].ToString());
                        processador.serial = reader["Serial"].ToString();
                        processador.codComputador = int.Parse(reader["FKCodComputador"].ToString());
                        processador.codUsuario = int.Parse(reader["FKCodUsuario"].ToString());
                        processadores.Add(processador);
                    }
                    reader.Close();
                }
                return processadores;
            }
        }

        public List<Processador> Selecionar(int codUsuario, int codComputador)
        {
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {

                connection.Open();

                string sql = ($"SELECT [CodProcessador],[NomeFabricante],[Modelo],[FrequenciaBase],[Nucleos],[Serial],[FKCodComputador],[FKCodUsuario] FROM [dbo].[Processador] " +
                    $"WHERE FKCodUsuairo = {codUsuario}" +
                    $"AND FKCodComputador = {codComputador}");

                List<Processador> processadores = new List<Processador>();

                SqlCommand command = new SqlCommand(sql, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Processador processador = new Processador();
                        processador.codProcessador = int.Parse(reader["CodProcessador"].ToString());
                        processador.nomeFabricante = reader["NomeFabricante"].ToString();
                        processador.modelo = reader["Modelo"].ToString();
                        processador.frequenciaBase = float.Parse(reader["FrequenciaBase"].ToString());
                        processador.nucleos = int.Parse(reader["Nucleos"].ToString());
                        processador.serial = reader["Serial"].ToString();
                        processador.codComputador = int.Parse(reader["FKCodComputador"].ToString());
                        processador.codUsuario = int.Parse(reader["FKCodUsuario"].ToString());
                        processadores.Add(processador);
                    }
                    reader.Close();
                }
                return processadores;
            }
        }

        public void Update(Processador obj)
        {
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {

                connection.Open();

                string sql = ($"UPDATE Processador SET " +
                    $"NomeFabricante = '{obj.nomeFabricante}', " +
                    $"Modelo = '{obj.modelo}' ," +
                    $"FrequenciaBase = '{obj.frequenciaBase.ToString().Replace(',','.')}' ," +
                    $"Serial = '{obj.serial}'" +
                    $" WHERE FKCodUsuario = {obj.codUsuario}" +
                    $" AND FKCodComputador = {obj.codComputador}");

                SqlCommand command = new SqlCommand(sql, connection);

                command.ExecuteNonQuery();
                connection.Close();

            }
        }
    }
}

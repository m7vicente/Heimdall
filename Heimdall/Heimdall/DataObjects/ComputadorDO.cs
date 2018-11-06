using Heimdall.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Heimdall.DataObjects
{
    public class ComputadorDO : DataObject<Computador>
    {
        public Computador buscar(Computador obj)
        {
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {

                connection.Open();

                string sql = ($"SELECT TOP(1) [CodComputador],[NomePersonalizado],[NomeComputador],[NomeFrabricante],[IPV4],[VersaoFirmeware],[FKCodUsuario] FROM[dbo].[Computador]" +
                                $"WHERE FKCodUsuario = {obj.codUsuario} " +
                                $"AND NomeComputador = '{obj.nomeComputador}'");

                SqlCommand command = new SqlCommand(sql, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        obj.codComputador = int.Parse(reader["CodComputador"].ToString());
                        obj.fabricanteComputador = reader["NomeFrabricante"].ToString();
                        obj.nomeComputador = reader["NomeComputador"].ToString();
                        obj.nomePersonalizado = reader["NomePersonalizado"].ToString();
                        obj.ipv4Computador = reader["IPV4"].ToString();
                        obj.versaoFirmware = reader["VersaoFirmeware"].ToString();
                    }
                    reader.Close();
                }
                return obj;
            }
        }

        public void Deletar(Computador obj)
        {
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {

                connection.Open();

                string sql = ($" DELETE [dbo].[Computador]" +
                    $"WHERE " +
                    $"[FKCodUsuario]) = {obj.codUsuario} " +
                    $"AND CodComputador = {obj.codComputador}");

                SqlCommand command = new SqlCommand(sql, connection);

                command.ExecuteNonQuery();
                connection.Close();

            }
        }

        public bool Inserir(Computador obj)
        {
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {

                connection.Open();

                string sql = ($" INSERT INTO[dbo].[Computador]([NomePersonalizado],[NomeComputador],[NomeFrabricante],[IPV4],[VersaoFirmeware],[FKCodUsuario])VALUES " +
                               $"('{obj.nomePersonalizado}'" +
                               $",'{obj.nomeComputador}'" +
                               $",'{obj.fabricanteComputador}'" +
                               $",'{obj.ipv4Computador}'" +
                               $",'{obj.versaoFirmware}'" +
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

        public List<Computador> Selecionar(int codUsuario)
        {
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                string sql = ($"SELECT [CodComputador],[NomePersonalizado],[NomeComputador],[NomeFrabricante],[IPV4],[VersaoFirmeware],[FKCodUsuario] FROM[dbo].[Computador]" +
                $"WHERE FKCodUsuario = {codUsuario}'");

                SqlCommand command = new SqlCommand(sql, connection);
                List<Computador> computadores = new List<Computador>();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Computador computador = new Computador();
                        computador.codComputador = int.Parse(reader["CodComputador"].ToString());
                        computador.fabricanteComputador = reader["NomeFrabricante"].ToString();
                        computador.nomeComputador = reader["NomeComputador"].ToString();
                        computador.nomePersonalizado = reader["NomePersonalizado"].ToString();
                        computador.ipv4Computador = reader["IPV4"].ToString();
                        computador.versaoFirmware = reader["VersaoFirmeware"].ToString();
                        computadores.Add(computador);
                    }
                    reader.Close();
                }
                return computadores;
            }
        }

        public List<Computador> Selecionar()
        {
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                string sql = ($"SELECT [CodComputador],[NomePersonalizado],[NomeComputador],[NomeFrabricante],[IPV4],[VersaoFirmeware],[FKCodUsuario] FROM[dbo].[Computador]");

                SqlCommand command = new SqlCommand(sql, connection);
                List<Computador> computadores = new List<Computador>();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Computador computador = new Computador();
                        computador.codComputador = int.Parse(reader["CodComputador"].ToString());
                        computador.fabricanteComputador = reader["NomeFrabricante"].ToString();
                        computador.nomeComputador = reader["NomeComputador"].ToString();
                        computador.nomePersonalizado = reader["NomePersonalizado"].ToString();
                        computador.ipv4Computador = reader["IPV4"].ToString();
                        computador.versaoFirmware = reader["VersaoFirmeware"].ToString();
                        computadores.Add(computador);
                    }
                    reader.Close();
                }
                return computadores;
            }
        }

        public void Update(Computador obj)
        {
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {

                connection.Open();

                string sql = ($" UPDATE [dbo].[Computador]" +
                    $"SET " +
                    $"([NomePersonalizado] = '{obj.nomePersonalizado}'" +
                    $",[NomeComputador] = '{obj.nomeComputador}'" +
                    $",[NomeFrabricante] = '{obj.fabricanteComputador}" +
                    $",[IPV4] = '{obj.ipv4Computador}'" +
                    $",[VersaoFirmeware] = '{obj.versaoFirmware}'" +
                    $"WHERE " +
                    $"[FKCodUsuario]) = {obj.codUsuario} " +
                    $"AND CodComputador = {obj.codComputador}");

                SqlCommand command = new SqlCommand(sql, connection);
                
                command.ExecuteNonQuery();
                connection.Close();

            }
        }
    }
}
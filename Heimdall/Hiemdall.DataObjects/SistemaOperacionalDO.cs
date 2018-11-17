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

        public SistemaOperacional buscar(int codComputador)
        {
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {

                connection.Open();

                string sql = ($"SELECT * FROM SistemaOperacional WHERE FKCodComputador = {codComputador}");

                SqlCommand command = new SqlCommand(sql, connection);

                SistemaOperacional obj = new SistemaOperacional();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        obj.codUsuario = int.Parse(reader["FKCodUsuario"].ToString());
                        obj.codComputador = int.Parse(reader["FKCodComputador"].ToString());
                        obj.codSO = int.Parse(reader["CodSO"].ToString());
                        obj.familiaSO = reader["familia"].ToString();
                        obj.versaoSO = reader["NomeVersao"].ToString();
                        obj.fabricanteSO = reader["NomeFabricante"].ToString();
                    }
                    reader.Close();
                }
                return obj;
            }
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

                string sql = ("INSERT INTO [dbo].[SistemaOperacional] ([NomeFabricante],[NomeVersao],[Familia],[FKCodComputador],[FKCodUsuario]) VALUES " +
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
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                connection.Open();

                string sql = ("UPDATE [dbo].[SistemaOperacional] SET " +
                    "[NomeFabricante]" + $" = '{obj.fabricanteSO}'" +
                    ",[NomeVersao]" + $" = '{obj.versaoSO}'" +
                    ",[Familia] = " + $"'{obj.familiaSO}'" +
                    " WHERE " +
                    " [FKCodComputador]" + $" = {obj.codComputador}" +
                    " AND [FKCodUsuario] " + $" = {obj.codUsuario}");


                SqlCommand command = new SqlCommand(sql, connection);

                command.ExecuteNonQuery();
                connection.Close();

            }
        }
    }
}
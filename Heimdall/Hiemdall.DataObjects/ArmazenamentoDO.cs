using Heimdall.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Heimdall.DataObjects
{
    public class ArmazenamentoDO : DataObject<Armazenamento>
    {

        public Armazenamento buscar(Armazenamento obj)
        {
            return obj;
        }
        public List<Armazenamento> buscar(int codComputador)
        {
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {

                connection.Open();

                string sql = ($"SELECT * FROM Armazenamento WHERE " +
                    $"FKCodComputador = {codComputador}");

                SqlCommand command = new SqlCommand(sql, connection);

                List<Armazenamento> armazenamentos = new List<Armazenamento>();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Armazenamento armazenamento = new Armazenamento();
                        armazenamento.codUsuario = int.Parse(reader["FKCodUsuario"].ToString());
                        armazenamento.codComputador = codComputador;
                        armazenamento.codUUID = reader["CodUUId"].ToString();
                        armazenamento.capacidadeTotal = double.Parse(reader["CapacidadeTotal"].ToString());
                        armazenamento.tipoArmazenamento = reader["TipoArmazenamento"].ToString();
                        armazenamentos.Add(armazenamento);
                    }
                    reader.Close();
                }
                connection.Close();
                return armazenamentos;
            }
        }
        public List<Armazenamento> buscarTodosEstados(int codUsuario, int codComputador)
        {
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {

                connection.Open();

                string sql = ($"SELECT A.CodUUId, A.TipoArmazenamento, A.CapacidadeTotal, H.CapacidadeUltilizada, H.LetraLocal, H.DataEstado FROM Armazenamento AS A " +
                    $"INNER JOIN HistoricoEstadoArmazenamento AS H ON A.CodUUId = H.FKCodUUId WHERE " +
                    $"A.FKCodComputador = {codComputador}" +
                    $"AND A.FKCodUsuario = {codUsuario}");

                SqlCommand command = new SqlCommand(sql, connection);

                List<Armazenamento> armazenamentos = new List<Armazenamento>();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Armazenamento armazenamento = new Armazenamento();
                        armazenamento.codUsuario = codUsuario;
                        armazenamento.codComputador = codComputador;
                        armazenamento.codUUID = reader["CodUUId"].ToString();
                        armazenamento.capacidadeUtilizada = double.Parse(reader["capacidadeUltilizada"].ToString());
                        armazenamento.capacidadeTotal = double.Parse(reader["CapacidadeTotal"].ToString());
                        armazenamento.tipoArmazenamento = reader["TipoArmazenamento"].ToString();
                        armazenamento.letraLocal = reader["LetraLocal"].ToString();
                        armazenamento.dataEstado = DateTime.Parse(reader["dataEstado"].ToString());
                        armazenamentos.Add(armazenamento);
                    }
                    reader.Close();
                }
                connection.Close();
                return armazenamentos;
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

                string sql = ("INSERT INTO [dbo].[Armazenamento] ([CodUUId],[TipoArmazenamento],[CapacidadeTotal],[FKCodComputador],[FKCodUsuario]) VALUES " +
                           $"('{obj.codUUID}'" +
                           $",'{obj.tipoArmazenamento}'" +
                           $",'{obj.capacidadeTotal.ToString().Replace(",", ".")}'" +
                           $", {obj.codComputador}" +
                           $", {obj.codUsuario})");

                SqlCommand command = new SqlCommand(sql, connection);

                if (command.ExecuteNonQuery() != 0)
                {
                    connection.Close();
                    HistoricoEstadoArmazenamentoDO historicoEstado = new HistoricoEstadoArmazenamentoDO();
                    historicoEstado.Inserir(obj);
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
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {

                connection.Open();

                string sql = ($"SELECT * FROM Armazenamento");

                SqlCommand command = new SqlCommand(sql, connection);

                List<Armazenamento> armazenamentos = new List<Armazenamento>();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Armazenamento armazenamento = new Armazenamento();
                        armazenamento.codComputador = int.Parse(reader["FKcodComputador"].ToString());
                        armazenamento.codUUID = reader["CodUUId"].ToString();
                        armazenamento.codUsuario = int.Parse(reader["FKCodUsuario"].ToString());
                        armazenamento.capacidadeTotal = double.Parse(reader["CapacidadeTotal"].ToString());
                        armazenamento.tipoArmazenamento = reader["TipoArmazenamento"].ToString();
                        armazenamentos.Add(armazenamento);
                    }
                    reader.Close();
                }
                connection.Close();
                return armazenamentos;
            }
        }

        public List<Armazenamento> Selecionar(int codUsuario, int codComputador)
        {
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {

                connection.Open();

                string sql = ($"SELECT * FROM Armazenamento" +
                    $"WHERE FKCodUsuario = {codUsuario}" +
                    $"AND FKCodComputador = {codComputador}");

                SqlCommand command = new SqlCommand(sql, connection);

                List<Armazenamento> armazenamentos = new List<Armazenamento>();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Armazenamento armazenamento = new Armazenamento();
                        armazenamento.codComputador = int.Parse(reader["FKcodComputador"].ToString());
                        armazenamento.codUUID = reader["CodUUId"].ToString();
                        armazenamento.codUsuario = int.Parse(reader["FKCodUsuario"].ToString());
                        armazenamento.capacidadeTotal = double.Parse(reader["CapacidadeTotal"].ToString());
                        armazenamento.tipoArmazenamento = reader["TipoArmazenamento"].ToString();
                        armazenamentos.Add(armazenamento);
                    }
                    reader.Close();
                }

                connection.Close();
                return armazenamentos;
            }
        }

        public void Update(Armazenamento obj)
        {
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {

                connection.Open();

                string sql = ("UPDATE [dbo].[Armazenamento] SET " +
                    $" [TipoArmazenamento] = '{obj.tipoArmazenamento}'" +
                    $", [CapacidadeTotal] = '{obj.capacidadeTotal.ToString().Replace(",", ".")}'" +
                    $" WHERE " +
                    $"[FKCodComputador] = {obj.codComputador}" +
                    $"AND [FKCodUsuario] = {obj.codUsuario}");

                SqlCommand command = new SqlCommand(sql, connection);

                command.ExecuteNonQuery();


                connection.Close();

            }
        }

        /*public void inserirHistorio(Armazenamento obj, SqlConnection connection)
        {
            string sql = ("INSERT INTO[dbo].[HistoricoEstadoArmazenamento] ([CapacidadeUltilizada],[LetraLocal],[FKCodUUId],[FKCodComputador],[FKCodUsuario]) VALUES " +
                   $"('{obj.capacidadeUtilizada}'" +
                   $",'{obj.letraLocal}'" +
                   $", {obj.codUUID}'" +
                   $", {obj.codComputador}" +
                   $", {obj.codUsuario})");

            SqlCommand command = new SqlCommand(sql, connection);

            command.ExecuteNonQuery();

        }*/
    }
}

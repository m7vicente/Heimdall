using Heimdall.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Heimdall.DataObjects
{
    public class HistoricoRAMDO : DataObject<HistoricoEstadoRam>
    {
        public HistoricoEstadoRam buscar(HistoricoEstadoRam obj)
        {
            throw new NotImplementedException();
        }

        public HistoricoEstadoRam buscar(int codComputador)
        {
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {

                connection.Open();

                string sql = ($" SELECT TOP 1 * FROM HistoricoEstadoRam WHERE FKCodComputador = {codComputador} ORDER BY DataEstado DESC");

                SqlCommand command = new SqlCommand(sql, connection);

                HistoricoEstadoRam obj = new HistoricoEstadoRam();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        obj.memoriaUtilizada = double.Parse(reader["Ultilizada"].ToString());
                        obj.memoriaDisponivel = double.Parse(reader["Disponivel"].ToString());
                        obj.swapTotal = double.Parse(reader["SwapTotal"].ToString());
                        obj.swapUtilizada = double.Parse(reader["SwapDisponivel"].ToString());
                        obj.memoriaTotal = double.Parse(reader["QuantidadeTotal"].ToString());
                        obj.porcentagemUtilizacao = int.Parse(reader["PorcentagemUltilizada"].ToString());
                        obj.codComputador = int.Parse(reader["FKCodComputador"].ToString());
                        obj.codUsuario = int.Parse(reader["FKCodUsuario"].ToString());
                    }
                    reader.Close();
                }
                return obj;
            }
        }

        public void Deletar(HistoricoEstadoRam obj)
        {
            throw new NotImplementedException();
        }

        public bool Inserir(HistoricoEstadoRam obj)
        {
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {

                connection.Open();

                string sql = ($" INSERT INTO[dbo].[HistoricoEstadoRam] ([Ultilizada], [Disponivel], [SwapTotal], [SwapDisponivel], [QuantidadeTotal], [PorcentagemUltilizada],[FKCodComputador],[FKCodUsuario]) VALUES " +
                            $"('{obj.memoriaUtilizada.ToString().Replace(",", ".")}'" +
                            $",'{obj.memoriaDisponivel.ToString().Replace(",", ".")}'" +
                            $",'{obj.swapTotal.ToString().Replace(",", ".")}'" +
                            $",'{obj.swapUtilizada.ToString().Replace(",", ".")}'" +//informação esta errada, favor corrigir
                            $",'{obj.memoriaTotal.ToString().Replace(",", ".")}'" +
                            $",{obj.porcentagemUtilizacao}" +
                            $",{obj.codComputador}" +
                            $",{obj.codUsuario})");

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

        public List<HistoricoEstadoRam> Selecionar()
        {
            throw new NotImplementedException();
        }

        public void Update(HistoricoEstadoRam obj)
        {
            throw new NotImplementedException();
        }
    }
}
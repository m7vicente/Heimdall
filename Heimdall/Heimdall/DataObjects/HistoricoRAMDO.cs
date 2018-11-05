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
                            $",'{obj.swapTotal.ToString().Replace(",",".")}'" +
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
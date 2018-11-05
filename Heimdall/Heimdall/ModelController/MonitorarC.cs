using Heimdall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Heimdall.ModelController
{
    public class MonitorarC
    {
        private ComputadorC computadorC = new ComputadorC();

        public MonitorarC(Usuario user)
        {
           
        }

        public void VerificarComputador(Usuario usuario)
        {
            usuario.computador.codUsuario = usuario.codUsuario;
            usuario.computador.RAM.codUsuario = usuario.codUsuario;
            usuario.computador.processadores.codUsuario = usuario.codUsuario;

            foreach (Armazenamento armazenamento in usuario.computador.armazenamentos)
            {
                armazenamento.codUsuario = usuario.codUsuario;
            }

            if (computadorC.VerificarCadastro(usuario.computador)){
                usuario.computador.codUsuario = usuario.codUsuario;
                
                usuario.computador.RAM.codUsuario = usuario.codUsuario;
                usuario.computador.RAM.codComputador = usuario.computador.codComputador;

                usuario.computador.processadores.codUsuario = usuario.codUsuario;
                usuario.computador.processadores.codComputador = usuario.computador.codComputador;

                foreach (Armazenamento armazenamento in usuario.computador.armazenamentos)
                {
                    armazenamento.codUsuario = usuario.codUsuario;
                    armazenamento.codComputador = usuario.computador.codComputador;
                }

                AtualizarEstados(usuario.computador.processadores,usuario.computador.RAM, usuario.computador.armazenamentos);
            }
            else
            {
                CadastrarComputador(usuario.computador);
            }
        }

        private void AtualizarEstados(Processador processador, HistoricoEstadoRam RAM, List<Armazenamento> armazenamentos)
        {

        }

        private void CadastrarComputador(Computador computador)
        {
            computadorC.Cadastrar(computador);

            computador.codUsuario = computador.codUsuario;

            computador.RAM.codUsuario = computador.codUsuario;
            computador.RAM.codComputador = computador.codComputador;

            computador.processadores.codUsuario = computador.codUsuario;
            computador.processadores.codComputador = computador.codComputador;

            computador.OS.codComputador = computador.codComputador;
            computador.OS.codUsuario = computador.codUsuario;

            foreach (Armazenamento armazenamento in computador.armazenamentos)
            {
                armazenamento.codUsuario = computador.codUsuario;
                armazenamento.codComputador = computador.codComputador;
            }
            
            ProcessadorC processadorC = new ProcessadorC();
            processadorC.Cadastrar(computador.processadores);

            HistoricoEstadoRAMC historicoEstadoRAMC = new HistoricoEstadoRAMC();
            historicoEstadoRAMC.Cadastrar(computador.RAM);

            ArmazenamentoC armazenamentoC = new ArmazenamentoC();
            foreach (Armazenamento armazenamento in computador.armazenamentos)
            {
                armazenamentoC.Cadastrar(armazenamento);
            }

            SistemaOperacionalC sistemaOperacionalC = new SistemaOperacionalC();
            sistemaOperacionalC.Cadastrar(computador.OS);
        }

    }
}
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
        private ProcessadorC processadorC = new ProcessadorC();
        private HistoricoEstadoRAMC historicoEstado = new HistoricoEstadoRAMC();
        private SistemaOperacionalC sistemaOperacionalC = new SistemaOperacionalC();
        private ArmazenamentoC armazenamentoC = new ArmazenamentoC();

        public MonitorarC()
        {

        }

        public void VerificarComputador(Usuario usuario)
        {
            usuario.computador.codUsuario = usuario.codUsuario;

            if (computadorC.VerificarCadastro(usuario.computador))
            {
                usuario.computador.codUsuario = usuario.codUsuario;

                usuario.computador.RAM.codUsuario = usuario.codUsuario;
                usuario.computador.RAM.codComputador = usuario.computador.codComputador;

                usuario.computador.processadores.codUsuario = usuario.codUsuario;
                usuario.computador.processadores.codComputador = usuario.computador.codComputador;

                usuario.computador.OS.codUsuario = usuario.codUsuario;
                usuario.computador.OS.codComputador = usuario.computador.codComputador;

                foreach (Armazenamento armazenamento in usuario.computador.armazenamentos)
                {
                    armazenamento.codUsuario = usuario.codUsuario;
                    armazenamento.codComputador = usuario.computador.codComputador;
                }

                AtualizarEstados(usuario.computador.processadores, usuario.computador.RAM, usuario.computador.armazenamentos, usuario.computador.OS, usuario.computador);
            }
            else
            {
                CadastrarComputador(usuario.computador);
            }
        }

        public void AtualizarComputador(Usuario user)
        {
            AtualizarEstados(user.computador.processadores, user.computador.RAM, user.computador.armazenamentos);
        }

        private void AtualizarEstados(Processador processador, HistoricoEstadoRam RAM, List<Armazenamento> armazenamentos)
        {

            processadorC.InserirEstado(processador);

            historicoEstado.Update(RAM);

            foreach (Armazenamento armazenamento in armazenamentos)
            {
                armazenamentoC.InserirEstado(armazenamento);
            }
        }

        private void AtualizarEstados(Processador processador, HistoricoEstadoRam RAM, List<Armazenamento> armazenamentos, SistemaOperacional SO, Computador computador)
        {
            processadorC.Update(processador);
            processadorC.InserirEstado(processador);

            historicoEstado.Update(RAM);
                        
            foreach (Armazenamento armazenamento in armazenamentos)
            {
                armazenamentoC.Update(armazenamento);
            }

            sistemaOperacionalC.Update(SO);

            computadorC.Update(computador);

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

            processadorC.Cadastrar(computador.processadores);


            historicoEstado.Cadastrar(computador.RAM);

            foreach (Armazenamento armazenamento in computador.armazenamentos)
            {
                armazenamentoC.Cadastrar(armazenamento);
            }

            sistemaOperacionalC.Cadastrar(computador.OS);
        }

        public Computador GetComputador(int codComputador)
        {   
            Computador computador = computadorC.BuscarComputador(codComputador);
            computador.armazenamentos = armazenamentoC.BuscarTodosArmazenamentos(codComputador);
            computador.processadores = processadorC.BuscarProcessador(codComputador);
            computador.OS = sistemaOperacionalC.BuscarSistemaOperacional(codComputador);
            computador.RAM = historicoEstado.BuscarRAM(codComputador);
                                 
            return computador;
        }


    }
}
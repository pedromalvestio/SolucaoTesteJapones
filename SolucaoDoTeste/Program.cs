using SolucaoDoTeste.Entidades;
using SolucaoDoTeste.RegrasDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucaoDoTeste
{
    class Program
    {
        static void Main(string[] args)
        {
            #region código antigo
            var estruturas = new Estruturas();
            var piloto = new Piloto();
            var oficialUm = new Oficial();
            var oficialDois = new Oficial();
            var chefeServico = new ChefeDeServico();
            var comissariaUm = new Comissaria();
            var comissariaDois = new Comissaria();
            var policial = new Policial();
            var prisioneiro = new Prisioneiro();

            estruturas.EmbarcaPassageiroTerminal(piloto);
            estruturas.EmbarcaPassageiroTerminal(oficialUm);
            estruturas.EmbarcaPassageiroTerminal(oficialDois);
            estruturas.EmbarcaPassageiroTerminal(chefeServico);
            estruturas.EmbarcaPassageiroTerminal(comissariaUm);
            estruturas.EmbarcaPassageiroTerminal(comissariaDois);
            estruturas.EmbarcaPassageiroTerminal(policial);
            estruturas.EmbarcaPassageiroTerminal(prisioneiro);

            Apresentacao.ApresentaLocaisPassageiros(estruturas);

            #region Policial Trasporta Prisioneiro Avião
            estruturas.EmbarcaMotoristaSmart(policial);
            Apresentacao.ApresentaLocaisPassageiros(estruturas);
            estruturas.EmbarcaPassageiroSmart(prisioneiro);
            Apresentacao.ApresentaLocaisPassageiros(estruturas);
            estruturas.TransportaPassageiros();
            estruturas.DesembarcaPassageiroSmart();
            Apresentacao.ApresentaLocaisPassageiros(estruturas);
            estruturas.TransportaPassageiros();
            Apresentacao.ApresentaLocaisPassageiros(estruturas);
            #endregion

            #region Policial Transporta Comissaria Avião e Busca Prisioneiro
            estruturas.EmbarcaPassageiroSmart(comissariaUm);
            estruturas.TransportaPassageiros();
            estruturas.DesembarcaPassageiroSmart();
            estruturas.EmbarcaPassageiroSmart(prisioneiro);
            estruturas.TransportaPassageiros();
            #endregion

            #region Policial e Prisioneiro no Terminal Chefe de serviço Transporta Comissaria para o Avião
            estruturas.DesembarcaPassageiroSmart();
            estruturas.DesembarcaMotoristaSmart();
            estruturas.EmbarcaPassageiroSmart(comissariaDois);
            estruturas.EmbarcaMotoristaSmart(chefeServico);
            estruturas.TransportaPassageiros();
            estruturas.DesembarcaPassageiroSmart();
            estruturas.TransportaPassageiros();
            #endregion

            #region Chefe de serviço Transporta Piloto para Avião ambos desembarcam Piloto retorna ao terminal
            estruturas.EmbarcaPassageiroSmart(piloto);
            estruturas.TransportaPassageiros();
            estruturas.DesembarcaPassageiroSmart();
            estruturas.DesembarcaMotoristaSmart();
            estruturas.EmbarcaMotoristaSmart(piloto);
            estruturas.TransportaPassageiros();
            #endregion

            #region Piloto desembarca no Terminal Policial transporta Priosioneiro Avião ambos desembarcam Chefe de serviço restorna ao terminal
            estruturas.DesembarcaMotoristaSmart();
            estruturas.EmbarcaMotoristaSmart(policial);
            estruturas.EmbarcaPassageiroSmart(prisioneiro);
            estruturas.TransportaPassageiros();
            estruturas.DesembarcaPassageiroSmart();
            estruturas.DesembarcaMotoristaSmart();
            estruturas.EmbarcaMotoristaSmart(chefeServico);
            estruturas.TransportaPassageiros();
            #endregion

            #region Chefe de serviço Transporta Piloto para Avião ambos desembarcam Piloto retorna ao terminal
            estruturas.EmbarcaPassageiroSmart(piloto);
            estruturas.TransportaPassageiros();
            estruturas.DesembarcaPassageiroSmart();
            estruturas.DesembarcaMotoristaSmart();
            estruturas.EmbarcaMotoristaSmart(piloto);
            estruturas.TransportaPassageiros();
            #endregion

            #region Piloto transporta Oficial para Avião ambos desembarcam Policial transporta Prisioneiro ao Terminal
            estruturas.EmbarcaPassageiroSmart(oficialUm);
            estruturas.TransportaPassageiros();
            estruturas.DesembarcaPassageiroSmart();
            estruturas.DesembarcaMotoristaSmart();
            estruturas.EmbarcaMotoristaSmart(policial);
            estruturas.EmbarcaPassageiroSmart(prisioneiro);
            estruturas.TransportaPassageiros();
            #endregion

            #region Prisioneiro desembarca Terminal Policial transporta Oficial ao Avião
            estruturas.DesembarcaPassageiroSmart();
            estruturas.EmbarcaPassageiroSmart(oficialDois);
            estruturas.TransportaPassageiros();
            estruturas.DesembarcaPassageiroSmart();
            estruturas.TransportaPassageiros();
            #endregion

            #region Policial transporta Prisioneiro Smat ambos desembarcam
            estruturas.EmbarcaPassageiroSmart(prisioneiro);
            estruturas.TransportaPassageiros();
            estruturas.DesembarcaPassageiroSmart();
            estruturas.DesembarcaMotoristaSmart();
            #endregion
            #endregion

            InterfaceUsuario interacaoUsuario = new InterfaceUsuario();

            interacaoUsuario.JogoExecucao();

            //Apresentacao.ApresentaLocaisPassageiros(estruturas);
        }
    }
}

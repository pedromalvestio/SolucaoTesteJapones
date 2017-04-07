using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolucaoDoTeste;
using SolucaoDoTeste.Entidades;
using SolucaoDoTeste.RegrasDeNegocio;
using SolucaoDoTeste.Interfaces;

namespace TesteSolucaoDeTeste
{
    [TestClass]
    public class TransportePassageirosTeste
    {
        #region Variaveis Teste
        Estruturas estruturas = new Estruturas();
        Piloto piloto = new Piloto();
        Oficial oficialUm = new Oficial();
        Oficial oficialDois = new Oficial();
        ChefeDeServico chefeServico = new ChefeDeServico();
        Comissaria comissariaUm = new Comissaria();
        Comissaria comissariaDois = new Comissaria();
        Policial policial = new Policial();
        Prisioneiro prisioneiro = new Prisioneiro();
        #endregion

        public void InicializaEstrutura()
        {
            estruturas.EmbarcaPassageiroTerminal(piloto);
            estruturas.EmbarcaPassageiroTerminal(oficialUm);
            estruturas.EmbarcaPassageiroTerminal(oficialDois);
            estruturas.EmbarcaPassageiroTerminal(chefeServico);
            estruturas.EmbarcaPassageiroTerminal(comissariaUm);
            estruturas.EmbarcaPassageiroTerminal(comissariaDois);
            estruturas.EmbarcaPassageiroTerminal(policial);
            estruturas.EmbarcaPassageiroTerminal(prisioneiro);
        }

        [TestMethod]
        public void EstruturaInicialTerminalValida()
        {
            InicializaEstrutura();
            Assert.IsTrue(ValidacaoPassageiros.VerifcarCondicaoPassageiros(estruturas.RetornaPassageirosTerminal()));
        }

        [TestMethod]
        public void EstruturaInicialSmartValida()
        {
            InicializaEstrutura();
            Assert.IsTrue(ValidacaoPassageiros.VerifcarCondicaoPassageiros(estruturas.RetornaPassageirosSmart()));
        }

        [TestMethod]
        public void EstruturaInicialAviaoValida()
        {
            InicializaEstrutura();
            Assert.IsTrue(ValidacaoPassageiros.VerifcarCondicaoPassageiros(estruturas.RetornaPassageirosAviao()));
        }

        [TestMethod]
        public void EmbarcarPassageiroTerminal()
        {
            estruturas.EmbarcaPassageiroTerminal(new object());
            Assert.IsTrue(estruturas.RetornaPassageirosTerminal().Count > 0);
        }

        [TestMethod]
        public void EmbarcarPassageiroTerminalSmart()
        {
            InicializaEstrutura();
            estruturas.EmbarcaPassageiroSmart(prisioneiro);
            Assert.IsTrue(estruturas.RetornaPassageirosSmart().Count > 0);
        }

        [TestMethod]
        public void EmbarcarMotoristaTerminalSmart()
        {
            InicializaEstrutura();
            estruturas.EmbarcaMotoristaSmart(piloto);
            Assert.IsTrue(estruturas.RetornaPassageirosSmart().Count > 0);
        }

        [TestMethod]
        public void ProibirEmbarcarMotoristaTerminalSmart()
        {
            InicializaEstrutura();
            estruturas.EmbarcaMotoristaSmart(prisioneiro);
            Assert.IsFalse(estruturas.RetornaPassageirosSmart().Count > 0);
        }

        [TestMethod]
        public void DesembarcarPassageiroTerminalSmart()
        {
            InicializaEstrutura();
            estruturas.EmbarcaPassageiroSmart(prisioneiro);
            estruturas.DesembarcaPassageiroSmart();
            Assert.IsTrue(estruturas.RetornaPassageirosSmart().Count == 0 && ValidacaoPassageiros.VeririficaPassageiroTipo(estruturas.RetornaPassageirosTerminal(), typeof(Prisioneiro)));
        }

        [TestMethod]
        public void DesembarcarMotoristaTerminalSmart()
        {
            InicializaEstrutura();
            estruturas.EmbarcaMotoristaSmart(piloto);
            estruturas.DesembarcaMotoristaSmart();
            Assert.IsTrue(estruturas.RetornaPassageirosSmart().Count == 0 && ValidacaoPassageiros.VeririficaPassageiroTipo(estruturas.RetornaPassageirosTerminal(), typeof(Piloto)));
        }

        [TestMethod]
        public void ProibirPilotoTransportarPrisioneiroSmart()
        {
            InicializaEstrutura();
            estruturas.EmbarcaMotoristaSmart(piloto);
            estruturas.EmbarcaPassageiroSmart(prisioneiro);
            Assert.IsFalse(ValidacaoPassageiros.VerifcarCondicaoPassageiros(estruturas.RetornaPassageirosSmart()));
        }

        [TestMethod]
        public void PilotoTransportarOficialSmart()
        {
            InicializaEstrutura();
            estruturas.EmbarcaMotoristaSmart(piloto);
            estruturas.EmbarcaPassageiroSmart(oficialUm);
            Assert.IsTrue(ValidacaoPassageiros.VerifcarCondicaoPassageiros(estruturas.RetornaPassageirosSmart()));
        }

        [TestMethod]
        public void ProibirPilotoTransportarComissariaSmart()
        {
            InicializaEstrutura();
            estruturas.EmbarcaMotoristaSmart(piloto);
            estruturas.EmbarcaPassageiroSmart(comissariaUm);
            Assert.IsFalse(ValidacaoPassageiros.VerifcarCondicaoPassageiros(estruturas.RetornaPassageirosSmart()));
        }

        [TestMethod]
        public void ProibirChefeDeServicoTransportarPrisioneiroSmart()
        {
            InicializaEstrutura();
            estruturas.EmbarcaMotoristaSmart(chefeServico);
            estruturas.EmbarcaPassageiroSmart(prisioneiro);
            Assert.IsFalse(ValidacaoPassageiros.VerifcarCondicaoPassageiros(estruturas.RetornaPassageirosSmart()));
        }

        [TestMethod]
        public void ChefeDeServicoTransportarComissariaSmart()
        {
            InicializaEstrutura();
            estruturas.EmbarcaMotoristaSmart(chefeServico);
            estruturas.EmbarcaPassageiroSmart(comissariaUm);
            Assert.IsTrue(ValidacaoPassageiros.VerifcarCondicaoPassageiros(estruturas.RetornaPassageirosSmart()));
        }

        [TestMethod]
        public void ProibirChefeDeServicoTransportarOficialSmart()
        {
            InicializaEstrutura();
            estruturas.EmbarcaMotoristaSmart(chefeServico);
            estruturas.EmbarcaPassageiroSmart(oficialUm);
            Assert.IsFalse(ValidacaoPassageiros.VerifcarCondicaoPassageiros(estruturas.RetornaPassageirosSmart()));
        }

        [TestMethod]
        public void VerificaStatusSmartTerminal()
        {
            InicializaEstrutura();
            estruturas.EmbarcaMotoristaSmart(chefeServico);
            estruturas.EmbarcaPassageiroSmart(oficialUm);
            Assert.IsTrue(estruturas.RetornaStausSmart() == typeof(SmartTerminal));
        }

        [TestMethod]
        public void VerificaStatusDiferenteSmartTerminal()
        {
            InicializaEstrutura();
            estruturas.EmbarcaMotoristaSmart(chefeServico);
            estruturas.EmbarcaPassageiroSmart(oficialUm);
            Assert.IsFalse(estruturas.RetornaStausSmart() != typeof(SmartTerminal));
        }

        [TestMethod]
        public void TransportarSmartTerminalAviao()
        {
            InicializaEstrutura();
            estruturas.EmbarcaMotoristaSmart(chefeServico);
            estruturas.EmbarcaPassageiroSmart(piloto);
            Assert.IsTrue(estruturas.TransportaPassageiros());
        }

        [TestMethod]
        public void VerificaStatusSmartAviao()
        {
            InicializaEstrutura();
            estruturas.EmbarcaMotoristaSmart(chefeServico);
            estruturas.EmbarcaPassageiroSmart(piloto);
            estruturas.TransportaPassageiros();
            Assert.IsTrue(estruturas.RetornaStausSmart() == typeof(SmartAviao));
        }

        [TestMethod]
        public void ProibirTransportarSmartAviaoComissariaComPilotoTerminal()
        {
            InicializaEstrutura();
            estruturas.EmbarcaMotoristaSmart(chefeServico);
            estruturas.EmbarcaPassageiroSmart(comissariaUm);
            Assert.IsFalse(estruturas.TransportaPassageiros());
        }

        [TestMethod]
        public void ProibirTransportarSmartAviaoOficialComChefeServicoTerminal()
        {
            InicializaEstrutura();
            estruturas.EmbarcaMotoristaSmart(piloto);
            estruturas.EmbarcaPassageiroSmart(oficialUm);
            Assert.IsFalse(estruturas.TransportaPassageiros());
        }

        [TestMethod]
        public void ProibirTransportarSmartAviaoPrisioneiroComPassageirosTerminal()
        {
            InicializaEstrutura();
            estruturas.EmbarcaMotoristaSmart(policial);
            Assert.IsFalse(estruturas.TransportaPassageiros());
        }

        [TestMethod]
        public void DesembarcarMotoristaAviao()
        {
            InicializaEstrutura();
            estruturas.EmbarcaMotoristaSmart(chefeServico);
            estruturas.EmbarcaPassageiroSmart(piloto);
            estruturas.TransportaPassageiros();
            estruturas.DesembarcaMotoristaSmart();
            Assert.IsTrue(estruturas.RetornaPassageirosAviao().Count > 0);
        }

        [TestMethod]
        public void DesembarcarPassageiroAviao()
        {
            InicializaEstrutura();
            estruturas.EmbarcaMotoristaSmart(chefeServico);
            estruturas.EmbarcaPassageiroSmart(piloto);
            estruturas.TransportaPassageiros();
            estruturas.DesembarcaPassageiroSmart();
            Assert.IsTrue(estruturas.RetornaPassageirosAviao().Count > 0);
        }

        [TestMethod]
        public void RetornaMotoristaAviaoTerminal()
        {
            InicializaEstrutura();
            estruturas.EmbarcaMotoristaSmart(chefeServico);
            estruturas.EmbarcaPassageiroSmart(piloto);
            estruturas.TransportaPassageiros();
            estruturas.DesembarcaPassageiroSmart();
            Assert.IsTrue(estruturas.TransportaPassageiros());
        }

        [TestMethod]
        public void RetornaMotoristaAviaoTerminalBuscaPassageiroAviao()
        {
            InicializaEstrutura();
            estruturas.EmbarcaMotoristaSmart(chefeServico);
            estruturas.EmbarcaPassageiroSmart(piloto);
            estruturas.TransportaPassageiros();
            estruturas.DesembarcaPassageiroSmart();
            estruturas.TransportaPassageiros();
            estruturas.EmbarcaPassageiroSmart(comissariaUm);
            estruturas.TransportaPassageiros();
            estruturas.DesembarcaPassageiroSmart();
            Assert.IsTrue(estruturas.RetornaPassageirosAviao().Count > 1);
        }

        [TestMethod]
        public void ProibirRetornarTerminalComissariaComPiloto()
        {
            InicializaEstrutura();
            estruturas.EmbarcaMotoristaSmart(chefeServico);
            estruturas.EmbarcaPassageiroSmart(piloto);
            estruturas.TransportaPassageiros();
            estruturas.DesembarcaPassageiroSmart();
            estruturas.TransportaPassageiros();
            estruturas.EmbarcaPassageiroSmart(comissariaUm);
            estruturas.TransportaPassageiros();
            estruturas.DesembarcaPassageiroSmart();
            Assert.IsFalse(estruturas.TransportaPassageiros());
        }

        [TestMethod]
        public void ResolucaoJogoSucesso()
        {
            InicializaEstrutura();

            #region Policial Trasporta Prisioneiro Avião
            estruturas.EmbarcaMotoristaSmart(policial);
            estruturas.EmbarcaPassageiroSmart(prisioneiro);
            estruturas.TransportaPassageiros();
            estruturas.DesembarcaPassageiroSmart();
            estruturas.TransportaPassageiros();
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

            Assert.IsTrue(ValidacaoPassageiros.VerificarTodosPassageirosAviao(estruturas.RetornaPassageirosAviao()));
        }

        [TestMethod]
        public void ResolucaoJogoErro()
        {
            InicializaEstrutura();
            Assert.IsFalse(ValidacaoPassageiros.VerificarTodosPassageirosAviao(estruturas.RetornaPassageirosAviao()));
        }

       
    }
}

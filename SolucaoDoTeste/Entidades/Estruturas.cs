using SolucaoDoTeste.Interfaces;
using SolucaoDoTeste.RegrasDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucaoDoTeste.Entidades
{
    public class Estruturas
    {
        private Terminal terminal;
        private Smart smart;
        private Aviao aviao;

        public Estruturas()
        {
            terminal = new Terminal();
            smart = new Smart();
            aviao = new Aviao();
        }

        public List<object> RetornaPassageirosTerminal()
        {
            return terminal.RetornaPassageiros();
        }

        public List<object> RetornaPassageirosAviao()
        {
            return aviao.RetornaPassageiros();
        }

        public List<object> RetornaPassageirosSmart()
        {
            return smart.RetornaPassageiros();
        }

        public List<String> RetornaPassageirosSmartApresentacao()
        {
            return smart.RetornaPassageirosApresentacao();
        }

        public Type RetornaStausSmart()
        {
            return smart.StateSmart.GetType();
        }

        public bool TransportaPassageiros()
        {
            if (ValidacaoPassageiros.VerifcarCondicaoPassageiros(RetornaPassageirosTerminal())
                && ValidacaoPassageiros.VerifcarCondicaoPassageiros(RetornaPassageirosSmart())
                && ValidacaoPassageiros.VerifcarCondicaoPassageiros(RetornaPassageirosAviao()))
            {
                smart.TansportaPassageiros();
                return true;
            }
            else return false;
        }

        public void EmbarcaMotoristaSmart(object motorista)
        {
            if (smart.StateSmart.GetType() == typeof(SmartTerminal))
                smart.EmbarcaMotorista(motorista, terminal);
            else
                smart.EmbarcaMotorista(motorista, aviao);
            
        }

        public void DesembarcaMotoristaSmart()
        {
            if (smart.StateSmart.GetType() == typeof(SmartTerminal))
                smart.DesembarcaMotorista(terminal);
            else
                smart.DesembarcaMotorista(aviao);
        }

        public void EmbarcaPassageiroSmart(object passageiro)
        {
            if (smart.StateSmart.GetType() == typeof(SmartTerminal))
                smart.EmbarcaPassageiro(passageiro, terminal);
            else
                smart.EmbarcaPassageiro(passageiro, aviao);
        }

        public void DesembarcaPassageiroSmart()
        {
            if (smart.StateSmart.GetType() == typeof(SmartTerminal))
                smart.DesembarcaPassageiro(terminal);
            else
                smart.DesembarcaPassageiro(aviao);
        }

        public void EmbarcaPassageiroTerminal(object passageiro)
        {
            terminal.EmbarcaPassageiro(passageiro);
        }
    }
}

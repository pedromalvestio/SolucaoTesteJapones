using SolucaoDoTeste.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucaoDoTeste.Entidades
{
    public class Smart
    {
        private ISmartState stateSmart;
        public ISmartState StateSmart
        {
            get
            {
                return stateSmart;
            }
            set
            {
                stateSmart = value;
            }
        }
            
        public object motorista;
        public object passageiro;

        public Smart()
        {
            motorista = null;
            passageiro = null;
            this.StateSmart = new SmartTerminal();
        }
        
        public List<object> RetornaPassageiros()
        {
            var listaPassageiros = new List<object>();
            if (motorista != null)
            {
                listaPassageiros.Add(motorista);
            }
            if (passageiro != null)
            {
                listaPassageiros.Add(passageiro);
            }
            return listaPassageiros;
        }

        public List<String> RetornaPassageirosApresentacao()
        {
            var listaPassageiros = new List<String>();
            if (motorista != null)
            {
                listaPassageiros.Add("Motorista: " + motorista.GetType().Name);
            }
            if (passageiro != null)
            {
                listaPassageiros.Add("Passageiro: " + passageiro.GetType().Name);
            }
            return listaPassageiros;
        }

        public void TansportaPassageiros()
        {
            StateSmart.TansportaPassageiros(this);
        }

        public void EmbarcaMotorista(object passageiro, object local)
        {
            StateSmart.EmbarcaMotorista(this, passageiro, local);
        }

        public void DesembarcaMotorista(object local)
        {
            StateSmart.DesembarcaMotorista(this, local);
        }

        public void EmbarcaPassageiro(object passageiro, object local)
        {
            StateSmart.EmbarcaPassageiro(this, passageiro, local);
        }

        public void DesembarcaPassageiro(object local)
        {
            StateSmart.DesembarcaPassageiro(this, local);
        }
    }
}

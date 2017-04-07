using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucaoDoTeste.Interfaces
{
    public abstract class EstruturaPassageirosBase
    {

        private List<object> passageiros;

        public EstruturaPassageirosBase()
        {
            passageiros = new List<object>();
        }

        public void InserePassageiros(List<object> passageiros)
        {
            this.passageiros = passageiros;
        }

        public bool VerificaPassageiro(object passageiro)
        {
            return this.passageiros.Contains(passageiro);
        }

        public void EmbarcaPassageiro(object passageiro)
        {
            this.passageiros.Add(passageiro);
        }

        public void DesembarcaPassageiro(object passageiro)
        {
            this.passageiros.Remove(passageiro);
        }

        public List<object> RetornaPassageiros()
        {
            return passageiros;
        }

    }
}

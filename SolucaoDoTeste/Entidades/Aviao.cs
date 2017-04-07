using SolucaoDoTeste.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucaoDoTeste.Entidades
{
    public class Aviao: EstruturaPassageirosBase
    {
        public Aviao()
        {

        }

        public Aviao(List<object> passageiros)
        {
            InserePassageiros(passageiros);
        }
    }
}


using SolucaoDoTeste.Entidades;
using SolucaoDoTeste.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucaoDoTeste.RegrasDeNegocio
{
    public class Apresentacao
    {
        public static void ApresentaAviao(List<String> listaPassageiros)
        {
            Console.WriteLine("-------AVIÃO------");
            Console.WriteLine("------------------");
            Console.WriteLine();
            ApresentaPassageiros(listaPassageiros);
        }

        public static void ApresentaSmart(List<String> listaPassageiros)
        {
            Console.WriteLine("-------SMART------");
            Console.WriteLine("------------------");
            Console.WriteLine();
            ApresentaPassageiros(listaPassageiros);
        }

        public static void ApresentaTerminal(List<String> listaPassageiros)
        {
            Console.WriteLine("-----TERMINAL-----");
            Console.WriteLine("------------------");
            Console.WriteLine();
            ApresentaPassageiros(listaPassageiros);
        }

        public static void ApresentaOpcaoEstruturas(Estruturas estruturas)
        {
            Console.WriteLine("");
            Console.WriteLine("Digite a opção desejada e pressione enter:");
            Console.WriteLine("");
            if (estruturas.RetornaStausSmart() == typeof(SmartTerminal))
            {
                Console.WriteLine("1. Terminal");
                Console.WriteLine("2. Smart");
                Console.WriteLine("3. Transportar passageiros para o Avião");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("4. Sair do jogo");
            }
            else
            {
                Console.WriteLine("1. Avião");
                Console.WriteLine("2. Smart");
                Console.WriteLine("3. Transportar passageiros para Terminal");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("4. Sair do jogo");
            }
        }

        public static void ApresentaFuncaoEstrutura(Type tipo)
        {
            Console.WriteLine("");
            Console.WriteLine("Digite a função desejada para {0} e pressione enter:", tipo.Name);
            Console.WriteLine("");
            if (tipo == typeof(Smart))
            {
                Console.WriteLine("1. Desembarca Motorista");
                Console.WriteLine("2. Desembarca Passageiro");
            }
            else
            {
                Console.WriteLine("1. Embarca Motorista no Smart");
                Console.WriteLine("2. Embarca Passageiro  no Smart");
            }
        }

        public static void ApresentaSelecaoPassageiro(string tipoPassageiro)
        {
            Console.WriteLine("");
            Console.WriteLine("Digite o {0} para embarcar no Smart e pressione enter:", tipoPassageiro);
            Console.WriteLine("");
        }

        public static void ApresentaPassageiros(List<String> listaPassageiros)
        {
            int item = 1;
            foreach (var passageiro in listaPassageiros)
            {
                Console.WriteLine("{0}. "+passageiro, item);
                item++;
            }
            Console.WriteLine();
        }

        public static void ApresentaLocaisPassageiros(Estruturas estrutura)
        {
            Console.WriteLine();
            Console.WriteLine("Transporte os passgeiros da CodeIT Airlines do Terminal até o Avião:");
            Console.WriteLine();
            ApresentaTerminal(RetornaNomePassageiros(estrutura.RetornaPassageirosTerminal()));
            ApresentaSmart(estrutura.RetornaPassageirosSmartApresentacao());
            ApresentaAviao(RetornaNomePassageiros(estrutura.RetornaPassageirosAviao()));
            //Console.ReadKey();
            //Console.Clear();
        }

        public static List<String> RetornaNomePassageiros(List<object> passageiros)
        {
            return passageiros.Select(x => x.GetType().Name).ToList();
        }
    }
}

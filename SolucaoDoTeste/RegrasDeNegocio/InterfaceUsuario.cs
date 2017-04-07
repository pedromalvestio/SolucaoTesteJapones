using SolucaoDoTeste.Entidades;
using SolucaoDoTeste.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucaoDoTeste.RegrasDeNegocio
{
    class InterfaceUsuario
    {
        Estruturas estruturas = new Estruturas();
        Piloto piloto = new Piloto();
        Oficial oficialUm = new Oficial();
        Oficial oficialDois = new Oficial();
        ChefeDeServico chefeServico = new ChefeDeServico();
        Comissaria comissariaUm = new Comissaria();
        Comissaria comissariaDois = new Comissaria();
        Policial policial = new Policial();
        Prisioneiro prisioneiro = new Prisioneiro();
        bool encerrarJogo = false;

        public InterfaceUsuario()
        {
            estruturas.EmbarcaPassageiroTerminal(piloto);
            estruturas.EmbarcaPassageiroTerminal(oficialUm);
            estruturas.EmbarcaPassageiroTerminal(oficialDois);
            estruturas.EmbarcaPassageiroTerminal(chefeServico);
            estruturas.EmbarcaPassageiroTerminal(comissariaUm);
            estruturas.EmbarcaPassageiroTerminal(comissariaDois);
            estruturas.EmbarcaPassageiroTerminal(policial);
            estruturas.EmbarcaPassageiroTerminal(prisioneiro);
            Apresentacao.ApresentaLocaisPassageiros(estruturas);
        }

        public void JogoExecucao()
        {
            while (!ValidacaoPassageiros.VerificarTodosPassageirosAviao(estruturas.RetornaPassageirosAviao()))
            {
                Apresentacao.ApresentaLocaisPassageiros(estruturas);
                SelecionaEstrutura();
                if (encerrarJogo)
                {
                    Console.WriteLine("Obrigado por jogar!");
                    break;
                }
                else
                {
                    Console.WriteLine("\n Pressione qualquer tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            Console.ReadKey();
        }

        public void SelecionaEstrutura()
        {
            Apresentacao.ApresentaOpcaoEstruturas(estruturas);
            switch (Console.ReadLine())
            {
                case "1":
                    SelecionaFuncaoEstrutura((estruturas.RetornaStausSmart() == typeof(SmartTerminal)) ? typeof(Terminal) : typeof(Aviao));
                    break;
                case "2":
                    SelecionaFuncaoEstrutura(typeof(Smart));
                    break;
                case "3":
                    estruturas.TransportaPassageiros();
                    break;
                case "4":
                    encerrarJogo = true;
                    break;
                default:
                    Console.WriteLine("A opção selecionada é inválida!");
                    break;
            }
        }

        public void SelecionaFuncaoEstrutura(Type tipo)
        {
            Apresentacao.ApresentaFuncaoEstrutura(tipo);
            if (tipo == typeof(Smart))
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        estruturas.DesembarcaMotoristaSmart();
                        break;
                    case "2":
                        estruturas.DesembarcaPassageiroSmart();
                        break;
                    default:
                        Console.WriteLine("A opção selecionada é inválida!");
                        break;
                }
            }
            else
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        estruturas.EmbarcaMotoristaSmart(SelecionaPassageiro("Motorista"));
                        break;
                    case "2":
                        estruturas.EmbarcaPassageiroSmart(SelecionaPassageiro("Passageiro"));
                        break;
                    default:
                        Console.WriteLine("A opção selecionada é inválida!");
                        break;
                }
            }
        }

        public object SelecionaPassageiro(string tipoPassageiro)
        {
            Apresentacao.ApresentaSelecaoPassageiro(tipoPassageiro);
            string valorDigitado = Console.ReadLine();
            int passageiro;
            if (int.TryParse(valorDigitado, out passageiro))
            {
                if (passageiro > 0)
                {
                    List<object> passageirosEstrutura = (estruturas.RetornaStausSmart() == typeof(SmartTerminal)
                        ? estruturas.RetornaPassageirosTerminal() : estruturas.RetornaPassageirosAviao());
                    if (passageirosEstrutura.Count >= passageiro)
                    {
                        passageiro--;
                        return passageirosEstrutura[passageiro];
                    }
                }
            }
            return null;
        }
    }
}

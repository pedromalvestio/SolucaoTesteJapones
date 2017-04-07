using SolucaoDoTeste.Entidades;
using SolucaoDoTeste.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucaoDoTeste.RegrasDeNegocio
{
    public class ValidacaoPassageiros
    {
        public static bool VerificarTodosPassageirosAviao(List<object> passageiros)
        {
            if (VeririficaPassageiroTipo(passageiros, typeof(ChefeDeServico)) &&
                VeririficaPassageiroTipoQuantidade(passageiros, typeof(Comissaria), 2) &&
                VeririficaPassageiroTipoQuantidade(passageiros, typeof(Oficial), 2) &&
                VeririficaPassageiroTipo(passageiros, typeof(Piloto)) &&
                VeririficaPassageiroTipo(passageiros, typeof(Policial)) &&
                VeririficaPassageiroTipo(passageiros, typeof(Prisioneiro)))
            {
                Console.WriteLine("Parabéns! Todos os passageiros foram embarcados no Avivão!");
                return true;
            }
            return false;
        }

        public static bool PassageiroPodeDirigir(object motorista)
        {
            if (motorista.GetType() == typeof(Policial) 
                || motorista.GetType() == typeof(Piloto) 
                || motorista.GetType() == typeof(ChefeDeServico))
                return true;
            else
            {
                Console.WriteLine();
                return false;
            }
        }

        public static bool VeririficaPassageiroEstrutura(List<object> passageiros, object passageiro)
        {
            return passageiros.Exists(x => x == passageiro);
        }

        public static bool VeririficaPassageiroTipo(List<object> passageiros, Type tipo)
        {
            return passageiros.Exists(x => x.GetType() == tipo);
        }

        public static bool VeririficaPassageiroTipoQuantidade(List<object> passageiros, Type tipo, int quantidade)
        {
            if (passageiros.Exists(x => x.GetType() == tipo))
            {
                if (passageiros.Count(x => x.GetType() == tipo) == quantidade)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool EstruturaValidaParaComissaria(List<object> passageiros)
        {
            bool verificaLocal = true;
            if (VeririficaPassageiroTipo(passageiros, typeof(Comissaria)))
            {
                if (!VeririficaPassageiroTipo(passageiros, typeof(ChefeDeServico))
                    && VeririficaPassageiroTipo(passageiros, typeof(Piloto)))
                {
                    verificaLocal = false;
                    Console.WriteLine("Comissária não pode ficar sozinha com Piloto");
                }
                if (!VeririficaPassageiroTipo(passageiros, typeof(Policial))
                    && VeririficaPassageiroTipo(passageiros, typeof(Prisioneiro)))
                {
                    verificaLocal = false;
                    Console.WriteLine("Passageiros não podem ficar sozinhos com Prisioneiro");
                }
            }
            return verificaLocal;
        }

        public static bool EstruturaValidaParaOficial(List<object> passageiros)
        {
            bool verificaLocal = true;
            if (VeririficaPassageiroTipo(passageiros, typeof(Oficial)))
            {
                if (VeririficaPassageiroTipo(passageiros, typeof(ChefeDeServico))
                    && !VeririficaPassageiroTipo(passageiros, typeof(Piloto)))
                {
                    verificaLocal = false;
                    Console.WriteLine("Oficial não pode ficar sozinho com Chefe de Serviço");
                }
                if (!VeririficaPassageiroTipo(passageiros, typeof(Policial))
                    && VeririficaPassageiroTipo(passageiros, typeof(Prisioneiro)))
                {
                    verificaLocal = false;
                    Console.WriteLine("Passageiros não podem ficar sozinhos com Prisioneiro");
                }
            }
            return verificaLocal;
        }

        public static bool VerificarLocalPrisioneiro(List<object> passageiros)
        {
            bool verificaLocal = true;
            if (VeririficaPassageiroTipo(passageiros, typeof(Prisioneiro)))
            {
                if (passageiros.Count() > 1)
                    if (!VeririficaPassageiroTipo(passageiros, typeof(Policial)))
                    {
                        verificaLocal = false;
                        Console.WriteLine("Passageiros não podem ficar sozinhos com Prisioneiro");
                    }
            }
            return verificaLocal;
        }

        public static bool VerifcarCondicaoPassageiros(List<object> passageiros)
        {
            return EstruturaValidaParaComissaria(passageiros) && EstruturaValidaParaOficial(passageiros) && VerificarLocalPrisioneiro(passageiros);
        }
    }
}

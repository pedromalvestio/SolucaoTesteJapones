using SolucaoDoTeste.Entidades;
using SolucaoDoTeste.RegrasDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucaoDoTeste.Interfaces
{
    public interface ISmartState
    {
        void TansportaPassageiros(Smart smart);
        void EmbarcaMotorista(Smart smart, object passageiro, object local);
        void DesembarcaMotorista(Smart smart, object local);
        void EmbarcaPassageiro(Smart smart, object passageiro, object local);
        void DesembarcaPassageiro(Smart smart, object local);
    }

    public class SmartTerminal : ISmartState
    {
        public void TansportaPassageiros(Smart smart)
        {
            if (smart.motorista != null)
            {
                smart.StateSmart = new SmartAviao();
                Console.WriteLine("Passageiros transportados parar o Avião");
            }
            else
                Console.WriteLine("Não é possível transportar passageiros sem motorista");
        }

        public void DesembarcaMotorista(Smart smart, object local)
        {
            if (smart.motorista != null)
            {
                if (!(local as Terminal).VerificaPassageiro(smart.motorista))
                {
                    (local as Terminal).EmbarcaPassageiro(smart.motorista);
                    Console.WriteLine("Motorista {0} foi desembarcado do Smart para o Terminal", smart.motorista.GetType().Name);
                    smart.motorista = null;
                }
            }
            else
                Console.WriteLine("Não existe Motorista no Smart");
        }

        public void DesembarcaPassageiro(Smart smart, object local)
        {
            if (smart.passageiro != null)
            {
                if (!(local as Terminal).VerificaPassageiro(smart.passageiro))
                {
                    (local as Terminal).EmbarcaPassageiro(smart.passageiro);
                    Console.WriteLine("Passageiro {0} desembarcado do Smart para o Terminal", smart.passageiro.GetType().Name);
                    smart.passageiro = null;
                }
            }
            else
                Console.WriteLine("Não existe Passageiro no Smart");
        }

        public void EmbarcaMotorista(Smart smart, object passageiro, object local)
        {
            if (smart.motorista == null && passageiro != null)
            {
                if ((local as Terminal).VerificaPassageiro(passageiro))
                {                    
                    if (ValidacaoPassageiros.PassageiroPodeDirigir(passageiro))
                    {
                        (local as Terminal).DesembarcaPassageiro(passageiro);
                        smart.motorista = passageiro;
                        Console.WriteLine("Motorista {0} embarcado no Smart", passageiro.GetType().Name);
                    }
                    else
                        Console.WriteLine("O passageiro {0} não pode dirigir o Smart", passageiro.GetType().Name);
                }
                else
                    Console.WriteLine("O motorista {0} está no Smart!", smart.motorista.GetType().Name);
            }
            else if (passageiro == null)
                Console.WriteLine("O motorista informado é inválido");
            else
                Console.WriteLine("O motorista {0} já está no Smart!", smart.motorista.GetType().Name);
        }

        public void EmbarcaPassageiro(Smart smart, object passageiro, object local)
        {
            if (smart.passageiro == null && passageiro != null)
            {
                if ((local as Terminal).VerificaPassageiro(passageiro))
                {
                    (local as Terminal).DesembarcaPassageiro(passageiro);
                    smart.passageiro = passageiro;
                    Console.WriteLine("Passageiro {0} embarcado no Smart", passageiro.GetType().Name);
                }
                else
                    Console.WriteLine("O passegeiro {0} não está no Terminal", passageiro.GetType().Name);
            }
            else if (passageiro == null)
                Console.WriteLine("O passageiro informado é inválido");
            else
                Console.WriteLine("O passageiro {0} já está no Smart!", smart.passageiro.GetType().Name);
        }
    }

    public class SmartAviao : ISmartState
    {
        public void TansportaPassageiros(Smart smart)
        {
            if (smart.motorista != null)
            {
                smart.StateSmart = new SmartTerminal();
                Console.WriteLine("Passageiros transportados parar o Terminal");
            }
            else
                Console.WriteLine("Não é possível transportar passageiros sem motorista");
        }

        public void DesembarcaMotorista(Smart smart, object local)
        {
            if (smart.motorista != null)
            {
                if (!(local as Aviao).VerificaPassageiro(smart.motorista))
                {
                    (local as Aviao).EmbarcaPassageiro(smart.motorista);
                    Console.WriteLine("Motorista {0} foi desembarcado do Smart para o Aviao", smart.motorista.GetType().Name);
                    smart.motorista = null;
                }
            }
            else
                Console.WriteLine("Não existe Motorista no Smart");
        }

        public void DesembarcaPassageiro(Smart smart, object local)
        {
            if (smart.passageiro != null)
            {
                if (!(local as Aviao).VerificaPassageiro(smart.passageiro))
                {
                    (local as Aviao).EmbarcaPassageiro(smart.passageiro);
                    Console.WriteLine("Passageiro {0} desembarcado do Smart para o Aviao", smart.passageiro.GetType().Name);
                    smart.passageiro = null;
                }
            }
            else
                Console.WriteLine("Não existe Passageiro no Smart");
        }

        public void EmbarcaMotorista(Smart smart, object passageiro, object local)
        {
            if (smart.motorista == null)
            {
                if ((local as Aviao).VerificaPassageiro(passageiro))
                {
                    if (ValidacaoPassageiros.PassageiroPodeDirigir(passageiro))
                    {
                        (local as Aviao).DesembarcaPassageiro(passageiro);
                        smart.motorista = passageiro;
                        Console.WriteLine("Motorista {0} embarcado no Smart", passageiro.GetType().Name);
                    }
                    else
                        Console.WriteLine("O passageiro {0} não pode dirigir o Smart", passageiro.GetType().Name);
                }
                else
                    Console.WriteLine("O motorista {0} está no Smart!", smart.motorista.GetType().Name);
            }
            else if (passageiro == null)
                Console.WriteLine("O motorista informado é inválido");
            else
                Console.WriteLine("O motorista {0} já está no Smart!", smart.motorista.GetType().Name);
        }

        public void EmbarcaPassageiro(Smart smart, object passageiro, object local)
        {
            if (smart.passageiro == null)
            {
                if ((local as Aviao).VerificaPassageiro(passageiro))
                {
                    (local as Aviao).DesembarcaPassageiro(passageiro);
                    smart.passageiro = passageiro;
                    Console.WriteLine("Passageiro {0} embarcado no Smart", passageiro.GetType().Name);
                }
                else
                    Console.WriteLine("O passegeiro {0} não está no Aviao", passageiro.GetType().Name);
            }
            else if (passageiro == null)
                Console.WriteLine("O passageiro informado é inválido");
            else
                Console.WriteLine("O passageiro {0} já está no Smart!", smart.passageiro.GetType().Name);
        }        
    }
}

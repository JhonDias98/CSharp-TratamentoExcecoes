using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank_Excecoes
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ContaCorrente conta1 = new ContaCorrente(6987, 213687);
                ContaCorrente conta2 = new ContaCorrente(3287, 634787);

                //conta1.Transferir(2000, conta2);
                conta1.Sacar(2000);
            }
            catch(OperacaoFinanceiraException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                Console.WriteLine("Informações da INNER EXCEPTION (exceção interna):");
                Console.WriteLine(e.InnerException.Message);
                Console.WriteLine(e.InnerException.StackTrace);
            }
            /*try
            {
                ContaCorrente conta2 = new ContaCorrente(146, 695432);

                ContaCorrente conta = new ContaCorrente(146, 326941);
                
                conta.Transferir(1000, conta2);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine("Argumento com problema: " + ex.ParamName);
                Console.WriteLine("Ocorreu uma exceção do tipo ArgumentException");
                Console.WriteLine(ex.Message);
            }
            catch(SaldoInsuficienteException ex)
            {
                Console.WriteLine(ex.Saldo);
                Console.WriteLine(ex.ValorSaque);

                Console.WriteLine(ex.StackTrace);

                Console.WriteLine(ex.Message);
                Console.WriteLine("Exceção do tipo SaldoInsuficienteException");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }*/
            Console.ReadLine();
        }
    }
}

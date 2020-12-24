using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank_Excecoes
{
    public class ContaCorrente
    {
        public static double TaxaOperacao { get; private set; }
        public Cliente Titular { get; set; }
        public static int TotalDeContasCriadas { get; private set; }
        public int ContadorSaqueNaoPermitidos { get; private set; }
        public int ContadorTransferenciasNaoPermitidas { get; private set; }
        public int Agencia { get; }
        //Readonly permite apenas leitura, só pode ter valores atribuídos no construtor
        //private readonly int _numero;
        public int Numero { get; }
        private double _saldo;
        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }
                else
                {
                    this._saldo = value;
                }
            }
        }

        public ContaCorrente(int agencia, int numero)
        {
            if (agencia <= 0)
            {
                throw new ArgumentException("O argumento Agencia deve ser maior que 0.", nameof(agencia));
            }
            if (numero <= 0)
            {
                throw new ArgumentException("O argumento Número deve ser maior que 0.", nameof(numero));
            }

            Agencia = agencia;
            Numero = numero;

            TotalDeContasCriadas++;
            TaxaOperacao = 30 / TotalDeContasCriadas;
        }

        public void Sacar(double valor)
        {
            if(valor < 0)
            {
                throw new ArgumentException("Valor inválido para o saque", nameof(valor));
            }
            if (this._saldo < valor)
            {
                ContadorSaqueNaoPermitidos++;
                throw new SaldoInsuficienteException(Saldo, valor);
            }
           
            this._saldo -= valor;
        }

        public void Depositar(double valor)
        {
            this._saldo += valor;
        }

        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para a transferência", nameof(valor));
            }

            try
            {
                Sacar(valor);
            }
            catch(SaldoInsuficienteException ex)
            {
                ContadorTransferenciasNaoPermitidas++;
                throw;
            }
            
            contaDestino.Depositar(valor);           
        }
    }
}
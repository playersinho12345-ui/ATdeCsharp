using System;
using System.Collections.Generic;
using System.Text;

namespace Exercicio7.models
{
    internal class ContaBancaria
    {
        public string titular;
        private decimal saldo;

        public ContaBancaria(string titular)
        {
            this.titular = titular;
            this.saldo = 0;
        }

        public void depositar(decimal deposito)
        {
            if (deposito <= 0)
            {
                Console.WriteLine("O valor do depósito deve ser positivo!");
            }
            else
            {
                saldo = deposito + saldo;
                Console.WriteLine($"Depósito de R$ {deposito:C} realizado com sucesso!");
                Console.WriteLine($"Saldo: {saldo:C}");
            }
        }

        public void sacar(decimal sacar)
        {
            if (sacar <= 0)
            {
                Console.WriteLine("O valor do saque deve ser positivo!");
            }
            else if (sacar > saldo)
            {
                Console.WriteLine($"Tentativa de Saque: {sacar:C}");
                Console.WriteLine("Saldo insuficiente para realizar o saque!");
            }
            else
            {
                saldo = saldo - sacar;
                Console.WriteLine($"Saque de R$ {sacar:C} realizado com sucesso!");
                Console.WriteLine($"Saldo: {saldo:C}");
            }
        }

        public void ExibirSaldo()
        {
            Console.WriteLine($"Saldo: {saldo:C}");
        }
    }
}
using System.Linq.Expressions;
using Exercicio7.models;

namespace Exercicio7
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ContaBancaria conta1 = new ContaBancaria("Gabriel Fiorini");

            conta1.sacar(1000);
            conta1.depositar(9000);
            conta1.sacar(900000);
            conta1.depositar(-1000);
            conta1.ExibirSaldo();
        }
    }
}

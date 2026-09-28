using exercicio8.models;

namespace exercicio8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Gerente gerente1 = new Gerente("Gabriel Fiorini", "Gerente Geral", 5000.0);
            System.Console.WriteLine("Salário: " + gerente1.ExibirSalario());
        }
    }
}

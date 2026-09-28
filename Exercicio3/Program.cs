using System.Security.Cryptography.X509Certificates;

namespace Exercicio3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double op1;
            double op2;
            int opcao = opcaoescolhida();


            Console.Write("Digite o primeiro operador: ");
            op1 = double.Parse(Console.ReadLine());
            Console.Write("Digite o segundo operador: ");
            op2 = double.Parse(Console.ReadLine());
            calcular(op1, op2, opcao);
        }

       
        /// MENU
        
        public static void introducao()
        {
            Console.WriteLine("Seja Bem-vindo à calculadora infneter.");
            Console.WriteLine("Qual seu nome?");
            String nome = Console.ReadLine();
            Console.WriteLine("Olá, " + nome + " qual operação desejaria executar?");
        }
        public static void exibirmenu()
        {
            Console.WriteLine("--- Calculadora ---");
            Console.WriteLine("[1] - Soma");
            Console.WriteLine("[2] - Subtração");
            Console.WriteLine("[3] - Multiplicação");
            Console.WriteLine("[4] - Divisão");
        }

        public static int opcaoescolhida()
        {
            int opcao = 0;
            introducao();
            exibirmenu();

            try
            {
                Console.WriteLine("Entre com o número correspondente à operação desejada.");
                opcao = int.Parse(Console.ReadLine());
            }

            catch (FormatException ex)
            {
                Console.WriteLine("Error: valor inválido - " + ex.Message);
            }

            return opcao;
            
        }
        public static void calcular(double op1, double op2, int opcao)
        {

            switch (opcao)
            {
                case 1:
                    soma(op1, op2);
                    break;

                case 2:
                    Subtrair(op1, op2);
                    break;

                case 3:
                    Multiplicar(op1, op2);
                    break;

                case 4:
                    Dividir(op1, op2);
                    break;

            }
        }

        /// OPERADORES
       
        public static void soma(double op1, double op2)
        {
            double result = op1 + op2;
            Console.WriteLine($"Soma = {result}");
        }
        public static void Subtrair(double op1, double op2)
        {
            double result = op1 - op2;
            Console.WriteLine($"Subtração = {result}");
        }

        public static void Multiplicar(double op1, double op2)
        {
            double result = op1 * op2;
            Console.WriteLine($"Multiplicação = {result}");
        }

        public static void Dividir(double op1, double op2)
        {
            double result;

            if (op2 == 0)
            {
                Console.WriteLine("Error: divisão por zero");
            }
            else
            {
                result = op1 / op2;
                Console.WriteLine($"Divisão: {result}");
            }
        }
    }
}

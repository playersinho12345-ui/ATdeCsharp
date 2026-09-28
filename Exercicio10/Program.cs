using System;

namespace Exercicio10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int numeroGerado = random.Next(1, 51);
            int tentativas = 5;

            Console.WriteLine("Tente adivinhar o número de 1 a 50!");

            for (int i = 0; i < tentativas; i++)
            {
                try
                {
                    Console.Write("Digite seu palpite: ");
                    int numeroTentado = int.Parse(Console.ReadLine());

                    if (numeroTentado < 1 || numeroTentado > 50)
                    {
                        Console.WriteLine("Erro: digite um número entre 1 e 50!");
                        i--;
                        continue;
                    }

                    if (numeroTentado == numeroGerado)
                    {
                        Console.WriteLine("Parabéns! Você acertou!");
                        break;
                    }
                    else if (numeroTentado < numeroGerado)
                    {
                        Console.WriteLine("O número secreto é maior.");
                    }
                    else
                    {
                        Console.WriteLine("O número secreto é menor.");
                    }

                    Console.WriteLine($"Tentativas restantes: {tentativas - i - 1}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Erro: digite apenas números!");
                    i--;
                }
            }

            Console.WriteLine($"O número era: {numeroGerado}");
        }
    }
}
using System;
using System.Runtime.CompilerServices;

namespace Exercicio2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite seu nome: ");
            string nome = Console.ReadLine();

            char[] letras = nome.ToCharArray();

            for (int i = 0; i < letras.Length; i++)
            {
                if (char.IsUpper(letras[i]))
                {
                    int posicao = letras[i] - 'A'; /// Força o programa a transformar a letra em sua respectiva posição no alfabeto
                                                   /// Ex: letras[i] = D -> D - A = 2, Assim o programa irá ler D como sua forma numérica
                    posicao = (posicao + 2) % 26;
                    letras[i] = (char)('A' + posicao); /// Usamos (char) para que o programa agora leia a Letra e não sua respectiva forma numérica
                }
                else if (char.IsLower(letras[i]))
                {
                    int posicao = letras[i] - 'a';
                    posicao = (posicao + 2) % 26;
                    letras[i] = (char)('a' + posicao);
                }
            }

            Console.WriteLine(letras);

            /// Pensei inicialmente em rodar dois arrays de letras do alfabeto, porém seria muito ineficiente para a execução do programa.
            /// No entanto, como os valores "char" conseguem ser assimilados à um valor numérico seria bem mais eficiente calcular suas 
            /// posicões por números.

        }
    }
}

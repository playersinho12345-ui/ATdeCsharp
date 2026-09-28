using Exercicio6.models;

namespace Exercicio6
{
    internal class main
    {
        static void Main(string[] args)
        {
            Aluno gabriel = new Aluno(
                "Gabriel Fiorini",
                "149CX239Z",
                "Engenharia de Software",
                8.7);

            gabriel.ExibirDados();
            Console.WriteLine(gabriel.VerificarAprovacao());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Exercicio6.models
{
    internal class Aluno
    {

        string nome;
        string matricula;
        string curso;
        double media;

        public Aluno (string nome, string matricula, string curso, double media)
        {
            this.nome = nome;
            this.matricula = matricula;
            this.curso = curso;
            this.media = media;
        }

        public void ExibirDados()
        {
            Console.WriteLine("==============================");
            Console.WriteLine($"{"Nome:",-15}{nome}");
            Console.WriteLine($"{"Matrícula:",-15}{matricula}");
            Console.WriteLine($"{"Curso:",-15}{curso}");
            Console.WriteLine($"{"Média:",-15}{media:F2}");
            Console.WriteLine("==============================");
        }

        public string VerificarAprovacao()
        {
            if (media >= 7)
            {
                return "Aprovado";
            }
            else
            {
                return "Reprovado";
            }
        }
    }
}

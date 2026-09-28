using System;
using System.Collections.Generic;
using System.Text;

namespace Exercicio12
{
    internal class MarkdownFormatter : ContatoFormatter
    {
        public override void ExibirContatos(List<Contato> contatos)
        {
            Console.WriteLine("## Lista de Contatos");

            foreach (Contato contato in contatos)
            {
                Console.WriteLine($"- **Nome:** {contato.Nome}");
                Console.WriteLine($"- Telefone: {contato.Telefone}");
                Console.WriteLine($"- Email: {contato.Email}");
            }
        }
    }
}
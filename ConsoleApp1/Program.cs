namespace Exercicio4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("=== Dias até seu aniversário! ===");
            Console.WriteLine("Insira sua data de nascimento: (DD/MM/YYYY)");
            string SdataNascimento = Console.ReadLine();

            DateTime dataNascimento = DateTime.Parse(SdataNascimento);

            DateTime dataAtual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            DateTime proxAniv = new DateTime(DateTime.Now.Year, dataNascimento.Month, dataNascimento.Day);

            if (dataAtual > proxAniv) { 
                
                proxAniv = proxAniv.AddYears(1);
            
            }

            TimeSpan diasfaltantes = proxAniv - dataAtual;
            
            if (diasfaltantes.Days < 7)
            {
                Console.WriteLine($"Faltam apenas {diasfaltantes.Days} dia(s) para seu aniversário, fique ligado!");
            } else
            {
                Console.WriteLine("Faltam " + diasfaltantes.Days + " dia(s) para seu aniversário!!!");
            }
        }
    }
}


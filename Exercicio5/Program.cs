namespace Exercicio5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Calculadora de dias faltantes ---");
            Console.WriteLine("Insira a data atual: (DD/MM/YYYY)");
            string SdataAtual = Console.ReadLine();
            DateTime dataAtual = DateTime.Parse(SdataAtual);

            DateTime conclusaoCurso = new DateTime(2029, 11, 28);

            if (dataAtual > DateTime.Now.Date)
            {

                Console.WriteLine("Erro: A data informada não pode ser no futuro!");
                return;
            }


            int anos = conclusaoCurso.Year - dataAtual.Year;
            int meses = conclusaoCurso.Month - dataAtual.Month;
            int dias = conclusaoCurso.Day - dataAtual.Day;

            
            if (dias < 0)
            {
                meses = meses - 1;

                DateTime mesAnterior = conclusaoCurso.AddMonths(-1);

                int diasDoMesAnterior = DateTime.DaysInMonth(
                    mesAnterior.Year,
                    mesAnterior.Month
                );

                dias = dias + diasDoMesAnterior;
            }

            if (meses < 0) {

                anos = anos - 1;
                meses = meses + 12;
            }

            Console.WriteLine($"Faltam {anos} ano(s), {meses} mês(es) e {dias} dia(s) para sua formatura!");


            if (meses < 6 && anos == 0)
            {
                Console.WriteLine($"Faltam {meses} mês(es) e {dias} dia(s) para sua formatura!");
                Console.WriteLine("A reta final chegou! Prepare-se para a formatura!");
            }

            if (dataAtual >= conclusaoCurso)
            {
                Console.WriteLine("Parabéns! Você já deveria estar formado!");
            }

        }
    }
}

namespace Exercicio12
{
    internal class Program
    {
        static string pathARQ = "C:\\Users\\lbrne\\source\\repos\\ATdoLP\\Exercicio12\\contatos.txt";

        static List<Contato> contatos = new List<Contato>();

        static void Main(string[] args)
        {
            int opcaoEscolhida;

            LerArquivo();

            do
            {
                ExibirMenu();
                opcaoEscolhida = EscolherOpcao();

                if (opcaoEscolhida == 1)
                {
                    AdicionarContato();
                }
                else if (opcaoEscolhida == 2)
                {
                    EscolherFormato();
                }
                else if (opcaoEscolhida == 3)
                {
                    Console.WriteLine("Programa encerrado.");
                }
                else
                {
                    Console.WriteLine("Opção inválida.");
                }

            } while (opcaoEscolhida != 3);
        }

        public static void ExibirMenu()
        {
            Console.WriteLine("\n=== Gerenciador de Contatos ===");
            Console.WriteLine("1: Adicionar novo contato");
            Console.WriteLine("2: Listar contatos");
            Console.WriteLine("3: Sair");
        }

        public static int EscolherOpcao()
        {
            Console.Write("Escolha uma opção: ");
            return int.Parse(Console.ReadLine());
        }

        public static void AdicionarContato()
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Contato contato = new Contato(nome, telefone, email);

            contatos.Add(contato);

            try
            {
                using (var arquivo = new StreamWriter(pathARQ, true))
                {
                    arquivo.WriteLine(
                        $"{nome},{telefone},{email}"
                    );
                }

                Console.WriteLine("Contato cadastrado com sucesso!\n");
            }
            catch (IOException ex)
            {
                Console.WriteLine("Erro ao salvar o contato: " + ex.Message);
            }
        }

        public static void LerArquivo()
        {
            try
            {
                if (!File.Exists(pathARQ))
                {
                    File.Create(pathARQ).Close();
                    return;
                }

                using (var arquivo = new StreamReader(pathARQ))
                {
                    string linha = arquivo.ReadLine();

                    while (linha != null)
                    {
                        string[] dados = linha.Split(',');

                        if (dados.Length != 3)
                        {
                            Console.WriteLine("Erro: contato com formato inválido.");
                            linha = arquivo.ReadLine();
                            continue;
                        }

                        Contato contato = new Contato(
                            dados[0],
                            dados[1],
                            dados[2]
                        );

                        contatos.Add(contato);

                        linha = arquivo.ReadLine();
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Erro de leitura do arquivo: " + ex.Message);
            }
        }

        public static void EscolherFormato()
        {
            if (contatos.Count == 0)
            {
                Console.WriteLine("Nenhum contato cadastrado.");
                return;
            }

            Console.WriteLine("\n=== Formato de Exibição ===");
            Console.WriteLine("1: Markdown");
            Console.WriteLine("2: Tabela");
            Console.WriteLine("3: Texto Puro");

            Console.Write("Escolha um formato: ");
            int formato = int.Parse(Console.ReadLine());

            ContatoFormatter formatter;

            if (formato == 1)
            {
                formatter = new MarkdownFormatter();
            }
            else if (formato == 2)
            {
                formatter = new TabelaFormatter();
            }
            else if (formato == 3)
            {
                formatter = new RawTextFormatter();
            }
            else
            {
                Console.WriteLine("Formato inválido.");
                return;
            }

            formatter.ExibirContatos(contatos);
        }
    }
}
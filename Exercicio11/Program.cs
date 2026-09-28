namespace Exercicio11
{
    internal class Program
    {
        static string pathARQ = "C:\\Users\\lbrne\\source\\repos\\ATdoLP\\Exercicio11\\contatos.txt";
        const int TAM = 10; /// Nome, Telefone, Email

        static string[] nomes = new string[TAM];
        static string[] telefones = new string[TAM];
        static string[] emails = new string[TAM];

        static int cont = 0;

        static void Main(string[] args)
        {
            int opcaoEscolhida;

            cont = LerArquivo();

            do
            {
                ExibirMenu();
                opcaoEscolhida = EscolherOpcao();

                if (opcaoEscolhida == 1)
                {
                    cont = AdicionarContato();
                }
                else if (opcaoEscolhida == 2)
                {
                    ListarContatos();
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

        public static int LerArquivo()
        {
            int cont = 0;

            try
            {
                if (!File.Exists(pathARQ))
                {
                    File.Create(pathARQ).Close();
                    return cont;
                }

                using (var arquivo = new StreamReader(pathARQ))
                {
                    string linha = arquivo.ReadLine();

                    while (linha != null && cont < TAM)
                    {
                        string[] dados = linha.Split(',');

                        if (dados.Length != 3)
                        {
                            Console.WriteLine("Erro: contato com formato inválido.");
                            linha = arquivo.ReadLine();
                            continue;
                        }

                        nomes[cont] = dados[0];
                        telefones[cont] = dados[1];
                        emails[cont] = dados[2];

                        cont++;

                        linha = arquivo.ReadLine();
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Erro de leitura do arquivo: " + ex.Message);
            }

            return cont;
        }

        public static void ExibirMenu()
        {
            Console.WriteLine("\n=== Gerenciador de Contatos ===");
            Console.WriteLine("1: Adicionar novo contato");
            Console.WriteLine("2: Listar contatos cadastrados");
            Console.WriteLine("3: Sair");
        }

        public static int EscolherOpcao()
        {
            Console.Write("Escolha uma opção: ");
            return int.Parse(Console.ReadLine());
        }

        public static int AdicionarContato()
        {
            if (cont == TAM)
            {
                Console.WriteLine("Limite atingido!");
                return cont;
            }

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            nomes[cont] = nome;
            telefones[cont] = telefone;
            emails[cont] = email;

            try
            {
                using (var arquivo = new StreamWriter(pathARQ, true))
                {
                    arquivo.WriteLine(
                        $"{nome},{telefone},{email}"
                    );
                }

                cont++;

                Console.WriteLine("Contato cadastrado com sucesso!\n");
            }
            catch (IOException ex)
            {
                Console.WriteLine("Erro ao salvar o contato: " + ex.Message);
            }

            return cont;
        }

        public static void ListarContatos()
        {
            cont = LerArquivo();

            if (cont == 0)
            {
                Console.WriteLine("Nenhum contato cadastrado.");
                return;
            }

            Console.WriteLine("\n=== Contatos Cadastrados ===");

            for (int i = 0; i < cont; i++)
            {
                Console.WriteLine(
                    $"Nome: {nomes[i]} | Telefone: {telefones[i]} | Email: {emails[i]}"
                );
            }
        }
    }
}
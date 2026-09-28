using System;

namespace Exercicio9
{
    internal class Program
    {
        const int TAM = 5;
        const string pathARQ = "C:\\Users\\lbrne\\source\\repos\\ATdoLP\\Exercicio9\\estoque.txt";

        static string[] nomes = new string[TAM];
        static int[] quantidades = new int[TAM];
        static double[] precos = new double[TAM];

        static int cont = 0;

        static void Main(string[] args)
        {
            cont = LerArquivo();

            int opcaoEscolhida;

            do
            {
                ExibirMenu();
                opcaoEscolhida = EscolherOpcao();

                if (opcaoEscolhida == 1)
                {
                    cont = InserirProduto();
                }
                else if (opcaoEscolhida == 2)
                {
                    ExibirProdutos();
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
            Console.WriteLine("\n=== Registro de Produtos ===");
            Console.WriteLine("1: Inserir Produto");
            Console.WriteLine("2: Listar Produtos");
            Console.WriteLine("3: Sair");
        }

        public static int EscolherOpcao()
        {
            Console.Write("Escolha uma opção: ");
            return int.Parse(Console.ReadLine());
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
                            Console.WriteLine("Erro: produto com formato inválido.");
                            linha = arquivo.ReadLine();
                            continue;
                        }

                        try
                        {
                            nomes[cont] = dados[0];
                            quantidades[cont] = int.Parse(dados[1]);
                            precos[cont] = double.Parse(
                                dados[2],
                                System.Globalization.CultureInfo.InvariantCulture
                            );

                            cont++;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Erro: dados de produto inválidos.");
                        }

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

        public static int InserirProduto()
        {
            if (cont == TAM)
            {
                Console.WriteLine("Limite de produtos atingido!");
                return cont;
            }

            Console.Write("Nome do produto: ");
            string nome = Console.ReadLine();

            Console.Write("Quantidade em estoque: ");
            int quantidade = int.Parse(Console.ReadLine());

            Console.Write("Preço unitário: ");
            double preco = double.Parse(Console.ReadLine());

            nomes[cont] = nome;
            quantidades[cont] = quantidade;
            precos[cont] = preco;

            try
            {
                using (var arquivo = new StreamWriter(pathARQ, false))
                {
                    arquivo.WriteLine(
                        $"{nome},{quantidade},{preco.ToString(System.Globalization.CultureInfo.InvariantCulture)}"
                    );
                }

                cont++;

                Console.WriteLine("Produto cadastrado com sucesso!");
            }
            catch (IOException ex)
            {
                Console.WriteLine("Erro ao salvar o produto: " + ex.Message);
            }

            return cont;
        }

        public static void ExibirProdutos()
        {
            if (cont == 0)
            {
                Console.WriteLine("Nenhum produto cadastrado.");
                return;
            }

            Console.WriteLine("\n=== Produtos Cadastrados ===");

            for (int i = 0; i < cont; i++)
            {
                Console.WriteLine(
                    $"Produto: {nomes[i]} | Quantidade: {quantidades[i]} | Preço: R$ {precos[i]:F2}"
                );
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<(int, string, int, double)> estoque = new List<(int, string, int, double)>();

    static void Main()
    {
        while (true)
        {
            MostrarMenu();
            string escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    CadastrarProduto();
                    break;
                case "2":
                    ConsultarProduto();
                    break;
                case "3":
                    AtualizarEstoque();
                    break;
                case "4":
                    GerarRelatorios();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void MostrarMenu()
    {
        Console.WriteLine("1. Cadastro de Produtos");
        Console.WriteLine("2. Consulta de Produtos por Código");
        Console.WriteLine("3. Atualização de Estoque");
        Console.WriteLine("4. Relatórios");
        Console.WriteLine("5. Sair");
        Console.Write("Escolha uma opção: ");
    }

    static void CadastrarProduto()
    {
        try
        {
            Console.Write("Código do produto: ");
            int codigo = LerInteiroPositivo();

            Console.Write("Nome do produto: ");
            string nome = Console.ReadLine();

            Console.Write("Quantidade em estoque: ");
            int quantidade = LerInteiroPositivo();

            Console.Write("Preço unitário: ");
            double preco = LerDoublePositivo();

            estoque.Add((codigo, nome, quantidade, preco));

            Console.WriteLine("Produto cadastrado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    static void ConsultarProduto()
    {
        try
        {
            Console.Write("Digite o código do produto: ");
            int codigo = LerInteiroPositivo();

            var produto = estoque.FirstOrDefault(p => p.Item1 == codigo);

            if (produto == default)
            {
                throw new ProdutoNaoEncontradoException("Produto não encontrado.");
            }

            ImprimirProduto(produto);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    static void AtualizarEstoque()
    {
        try
        {
            Console.Write("Digite o código do produto: ");
            int codigo = LerInteiroPositivo();

            var produto = estoque.FirstOrDefault(p => p.Item1 == codigo);

            if (produto == default)
            {
                throw new ProdutoNaoEncontradoException("Produto não encontrado.");
            }

            Console.Write("Digite a quantidade a ser adicionada (+) ou removida (-): ");
            int quantidadeAtualizacao = LerInteiro();

            if (produto.Item3 + quantidadeAtualizacao < 0)
            {
                throw new EstoqueInsuficienteException("Estoque insuficiente para a quantidade especificada.");
            }

            produto.Item3 += quantidadeAtualizacao;

            Console.WriteLine("Estoque atualizado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    static void GerarRelatorios()
    {
        try
        {
            Console.Write("Informe o limite de quantidade para o relatório 1: ");
            int limiteQuantidade = LerInteiroPositivo();

            var relatorio1 = estoque.Where(p => p.Item3 < limiteQuantidade);
            Console.WriteLine("Relatório 1: Produtos com quantidade em estoque abaixo do limite");
            ImprimirRelatorio(relatorio1);

            Console.Write("Informe o valor mínimo para o relatório 2: ");
            double valorMinimo = LerDouble();

            Console.Write("Informe o valor máximo para o relatório 2: ");
            double valorMaximo = LerDouble();

            var relatorio2 = estoque.Where(p => p.Item4 >= valorMinimo && p.Item4 <= valorMaximo);
            Console.WriteLine("Relatório 2: Produtos com valor entre o mínimo e o máximo");
            ImprimirRelatorio(relatorio2);

            Console.WriteLine("Relatório 3: Valor total do estoque e valor total de cada produto");
            var valorTotalEstoque = estoque.Sum(p => p.Item3 * p.Item4);
            Console.WriteLine($"Valor total do estoque: {valorTotalEstoque:C}");

            foreach (var produto in estoque)
            {
                var valorTotalProduto = produto.Item3 * produto.Item4;
                Console.WriteLine($"Produto: {produto.Item2}, Valor Total: {valorTotalProduto:C}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    static int LerInteiro()
    {
        int valor;
        while (!int.TryParse(Console.ReadLine(), out valor))
        {
            Console.WriteLine("Entrada inválida. Tente novamente.");
        }
        return valor;
    }

    static int LerInteiroPositivo()
    {
        int valor;
        while (!int.TryParse(Console.ReadLine(), out valor) || valor < 0)
        {
            Console.WriteLine("Entrada inválida. Digite um valor inteiro não negativo.");
        }
        return valor;
    }

    static double LerDouble()
    {
        double valor;
        while (!double.TryParse(Console.ReadLine(), out valor))
        {
            Console.WriteLine("Entrada inválida. Tente novamente.");
        }
        return valor;
    }

    static double LerDoublePositivo()
    {
        double valor;
        while (!double.TryParse(Console.ReadLine(), out valor) || valor < 0)
        {
            Console.WriteLine("Entrada inválida. Digite um valor numérico não negativo.");
        }
        return valor;
    }

    static void ImprimirProduto((int, string, int, double) produto)
    {
        Console.WriteLine($"Nome: {produto.Item2}");
        Console.WriteLine($"Quantidade em estoque: {produto.Item3}");
        Console.WriteLine($"Preço unitário: {produto.Item4:C}");
    }

    static void ImprimirRelatorio(IEnumerable<(int, string, int, double)> relatorio)
    {
        foreach (var produto in relatorio)
        {
            Console.WriteLine($"Código: {produto.Item1}, Nome: {produto.Item2}, Quantidade: {produto.Item3}, Preço: {produto.Item4:C}");
        }
    }
}

class ProdutoNaoEncontradoException : Exception
{
    public ProdutoNaoEncontradoException(string message) : base(message)
    {
    }
}

class EstoqueInsuficienteException : Exception
{
    public EstoqueInsuficienteException(string message) : base(message)
    {
    }
}

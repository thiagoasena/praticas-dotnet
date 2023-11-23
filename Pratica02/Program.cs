using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<Task> tasks = new List<Task>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Criar Tarefa");
            Console.WriteLine("2. Listar Todas as Tarefas");
            Console.WriteLine("3. Marcar Tarefa como Concluída");
            Console.WriteLine("4. Listar Tarefas Pendentes");
            Console.WriteLine("5. Listar Tarefas Concluídas");
            Console.WriteLine("6. Excluir Tarefa");
            Console.WriteLine("7. Pesquisar Tarefas por Palavra-chave");
            Console.WriteLine("8. Exibir Estatísticas");
            Console.WriteLine("0. Sair");

            Console.Write("Escolha uma opção: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateTask();
                    break;
                case "2":
                    ListAllTasks();
                    break;
                case "3":
                    MarkTaskAsCompleted();
                    break;
                case "4":
                    ListPendingTasks();
                    break;
                case "5":
                    ListCompletedTasks();
                    break;
                case "6":
                    DeleteTask();
                    break;
                case "7":
                    SearchTasksByKeyword();
                    break;
                case "8":
                    DisplayStatistics();
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void CreateTask()
    {
        Console.Write("Digite o título da tarefa: ");
        string title = Console.ReadLine();

        Console.Write("Digite a descrição da tarefa: ");
        string description = Console.ReadLine();

        Console.Write("Digite a data de vencimento (no formato dd/mm/yyyy): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime dueDate))
        {
            Task task = new Task(title, description, dueDate);
            tasks.Add(task);

            Console.WriteLine("Tarefa criada com sucesso!");
        }
        else
        {
            Console.WriteLine("Formato de data inválido. Tarefa não criada.");
        }
    }

    static void ListAllTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Nenhuma tarefa encontrada.");
        }
        else
        {
            foreach (var task in tasks)
            {
                Console.WriteLine(task);
            }
        }
    }

    static void MarkTaskAsCompleted()
    {
        Console.Write("Digite o número da tarefa a ser marcada como concluída: ");
        if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber >= 1 && taskNumber <= tasks.Count)
        {
            tasks[taskNumber - 1].IsCompleted = true;
            Console.WriteLine("Tarefa marcada como concluída!");
        }
        else
        {
            Console.WriteLine("Número de tarefa inválido. Tente novamente.");
        }
    }

    static void ListPendingTasks()
    {
        var pendingTasks = tasks.Where(t => !t.IsCompleted).ToList();
        if (pendingTasks.Count == 0)
        {
            Console.WriteLine("Nenhuma tarefa pendente encontrada.");
        }
        else
        {
            foreach (var task in pendingTasks)
            {
                Console.WriteLine(task);
            }
        }
    }

    static void ListCompletedTasks()
    {
        var completedTasks = tasks.Where(t => t.IsCompleted).ToList();
        if (completedTasks.Count == 0)
        {
            Console.WriteLine("Nenhuma tarefa concluída encontrada.");
        }
        else
        {
            foreach (var task in completedTasks)
            {
                Console.WriteLine(task);
            }
        }
    }

    static void DeleteTask()
    {
        Console.Write("Digite o número da tarefa a ser excluída: ");
        if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber >= 1 && taskNumber <= tasks.Count)
        {
            tasks.RemoveAt(taskNumber - 1);
            Console.WriteLine("Tarefa excluída com sucesso!");
        }
        else
        {
            Console.WriteLine("Número de tarefa inválido. Tente novamente.");
        }
    }

    static void SearchTasksByKeyword()
    {
        Console.Write("Digite a palavra-chave para a pesquisa: ");
        string keyword = Console.ReadLine().ToLower();

        var matchingTasks = tasks.Where(t => t.Title.ToLower().Contains(keyword) || t.Description.ToLower().Contains(keyword)).ToList();

        if (matchingTasks.Count == 0)
        {
            Console.WriteLine("Nenhuma tarefa encontrada com a palavra-chave fornecida.");
        }
        else
        {
            foreach (var task in matchingTasks)
            {
                Console.WriteLine(task);
            }
        }
    }

    static void DisplayStatistics()
    {
        Console.WriteLine($"Número total de tarefas: {tasks.Count}");
        Console.WriteLine($"Número de tarefas concluídas: {tasks.Count(t => t.IsCompleted)}");
        Console.WriteLine($"Número de tarefas pendentes: {tasks.Count(t => !t.IsCompleted)}");

        if (tasks.Count > 0)
        {
            Console.WriteLine($"Tarefa mais antiga: {tasks.Min(t => t.DueDate)}");
            Console.WriteLine($"Tarefa mais recente: {tasks.Max(t => t.DueDate)}");
        }
    }
}

class Task
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }

    public Task(string title, string description, DateTime dueDate)
    {
        Title = title;
        Description = description;
        DueDate = dueDate;
        IsCompleted = false;
    }

    public override string ToString()
    {
        return $"Tarefa: {Title}\nDescrição: {Description}\nData de Vencimento: {DueDate}\nConcluída: {(IsCompleted ? "Sim" : "Não")}\n";
    }
}

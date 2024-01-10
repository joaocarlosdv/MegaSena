
using System.Diagnostics.CodeAnalysis;

class Program
{
    static void Main()
    {
        Console.WriteLine("Mega Sena");
        Menu();
    }

    static void Menu()
    {
        Console.WriteLine();
        Console.WriteLine("****************** Menu ******************");
        Console.WriteLine();
        Console.WriteLine("1 - Gerar Jogos");
        Console.WriteLine("2 - Encontrar Resultado");
        Console.WriteLine("Sair");
        Console.WriteLine();
        Console.Write("Opção: ");

        int opcao = 0;
        try
        {
            opcao = Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception)
        {
            opcao = 0;
        }

        switch (opcao)
        {
            case 1:
                Mega();
                break;
            case 2:
                probabilidade();
                break;
            default:                
                break;
        }
    }

    static void probabilidade()
    {
        Console.WriteLine();
        Console.WriteLine("****************** Encontrar Resultado ******************");
        Console.WriteLine();
        Console.Write("Informe o Resultado: ");
        string resultado = Console.ReadLine();  

        string jogo = Jogo();
        var total = 1;
        while (jogo != resultado)
        {
            jogo = Jogo();
            total++;
        }

        Console.WriteLine();
        Console.WriteLine("Foram Necessários "+ total + " jogos para acertar o resultado.");
        Menu();
    }

    static void Mega()
    {
        Console.WriteLine();
        Console.WriteLine("****************** Gerar Jogo ******************");
        Console.WriteLine();
        Console.Write("Informa a quantidade de Jogos: ");
        int qtd = 0;
        try
        {
            qtd = Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception)
        {
            qtd = 1;
        }
        Console.WriteLine();

        List<string> jogos = new List<string>();

        for (int x = 0; x < qtd; x++)
        {
            string jogo = Jogo();

            while (jogos.Where(y => y == jogo).Count() > 0)
            {
                jogo = Jogo();
            }
            jogos.Add(jogo);
        }


        foreach (var jogo in jogos.OrderBy(x => x))
        {
            Console.WriteLine(jogo);
        }
        Menu();
    }

    static string Jogo()
    {
        Random random = new Random();

        List<int> numeros = new List<int>();

        for (int i = 1; i <= 6; i++)
        {
            int num = random.Next(1, 61);
            while (numeros.Where(x => x == num).Count() > 0)
            {
                num = random.Next(1, 60);
            }
            numeros.Add(num);
        }

        string jogo = "";


        foreach (int num in numeros.OrderBy(x => x))
        {
            jogo += num.ToString() + "-";
        }

        return jogo.Substring(0, jogo.Length - 1);
    }
}








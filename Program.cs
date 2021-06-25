using System;

namespace ShowsRepository
{
  class Program
  {
    static Repository repository = new Repository();
    static void Main()
    {
      string userOption = GetUserOption();

      while (userOption.ToUpper() != "X")
      {
        switch (userOption)
        {
          case "1":
            ListShows();
            break;
          case "2":
            InserShow();
            break;
          case "3":
            UpdateShow();
            break;
          case "4":
            DeleteShow();
            break;
          case "5":
            CheckShow();
            break;
          case "C":
            Console.Clear();
            break;

          default:
            throw new ArgumentOutOfRangeException();
        }

        userOption = GetUserOption();
      }

      Console.WriteLine("Obrigado por utilizar nossos serviços.");
      Console.ReadLine();
    }

    private static void DeleteShow()
    {
      Console.Write("Digite o id da série: ");
      int index = int.Parse(Console.ReadLine());

      repository.Delete(index);
    }

    private static void CheckShow()
    {
      Console.Write("Digite o id da série: ");
      int index = int.Parse(Console.ReadLine());

      var show = repository.ReturnById(index);

      Console.WriteLine(show);
    }

    private static void UpdateShow()
    {
      Console.Write("Digite o id da série: ");
      int index = int.Parse(Console.ReadLine());

      foreach (int i in Enum.GetValues(typeof(Genre)))
      {
        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
      }
      Console.Write("Digite o gênero entre as opções acima: ");
      int genreEntry = int.Parse(Console.ReadLine());

      Console.Write("Digite o Título da Série: ");
      string TitleEntry = Console.ReadLine();

      Console.Write("Digite o Ano de Início da Série: ");
      int YearEntry = int.Parse(Console.ReadLine());

      Console.Write("Digite a Descrição da Série: ");
      string DescriptionEntry = Console.ReadLine();

      Show show = new Show(index, (Genre)genreEntry, TitleEntry, DescriptionEntry, YearEntry);

      repository.Update(index, show);
    }
    private static void ListShows()
    {
      Console.WriteLine("Listar séries");

      var list = repository.List();

      if (list.Count == 0)
      {
        Console.WriteLine("Nenhuma série cadastrada.");
        return;
      }

      foreach (Show show in list)
      {
        bool deleted = show.ReturnDeleted();

        Console.WriteLine("#ID {0}: - {1} {2}", show.ReturnId(), show.ReturnTitle(), (deleted ? "*Excluído*" : ""));
      }
    }

    private static void InserShow()
    {
      Console.WriteLine("Inserir nova série");

      foreach (int i in Enum.GetValues(typeof(Genre)))
      {
        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
      }
      Console.Write("Digite o gênero entre as opções acima: ");
      int genreEntry = int.Parse(Console.ReadLine());

      Console.Write("Digite o Título da Série: ");
      string TitleEntry = Console.ReadLine();

      Console.Write("Digite o Ano de Início da Série: ");
      int YearEntry = int.Parse(Console.ReadLine());

      Console.Write("Digite a Descrição da Série: ");
      string DescriptionEntry = Console.ReadLine();

      Show show = new Show(repository.NextId(), (Genre)genreEntry, TitleEntry, DescriptionEntry, YearEntry);

      repository.Insert(show);
    }

    private static string GetUserOption()
    {
      Console.WriteLine();
      Console.WriteLine("DIO Séries a seu dispor!!!");
      Console.WriteLine("Informe a opção desejada:");

      Console.WriteLine("1- Listar séries");
      Console.WriteLine("2- Inserir nova série");
      Console.WriteLine("3- Atualizar série");
      Console.WriteLine("4- Excluir série");
      Console.WriteLine("5- Visualizar série");
      Console.WriteLine("C- Limpar Tela");
      Console.WriteLine("X- Sair");
      Console.WriteLine();

      string userOption = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return userOption;
    }
  }
}

using CreateBooksDbScript.DataBase;
using CreateBooksDbScript.DB.Models;

namespace CreateBooksDbScript
{
  internal class Program
  {
    static void Main(string[] args)
    {
      var dbContext = new AppDbContext();
      Console.WriteLine($"Путь к базе данных:{AppDbContext.DbPath}");

      while (true)
      {
        Console.WriteLine("1. Отобразить книги по автору");
        Console.WriteLine("2. Отобразить книги по издательству");
        Console.WriteLine("0. Выход");
        Console.Write("Введите номер пункта:");
        var input = Console.ReadLine();
        switch (input)
        {
          case "1":
            PrintAllBooksByAuthor(dbContext);
            break;

          case "2":
            PrintAllBooksByPublishingHouse(dbContext);
            break;

          case "0":
            return;

          default:
            break;
        }
      }
    }

    /// <summary>
    /// Запрашивает автора и выводит все его книги в консоль.
    /// </summary>
    static private void PrintAllBooksByAuthor(AppDbContext appDbContext)
    {
      var autorService = new DataBase.Services.AutorService(appDbContext);
      var autors = autorService.GetAllAutors();
      AutorModel autor = null;

      foreach (var item in autors)
      {
        Console.WriteLine($"{item.Id}. {item.Surname} {item.Name} {item.Patronymic}");
      }

      Console.Write("Ввведите номер автора:");
      while (true)
      {
        var input = Console.ReadLine();
        if (!int.TryParse(input, out int number) || !autors.Any(x => x.Id == number))
        {
          Console.Write("Введите корректный номер автора:");
          continue;
        }

        autor = autors.First(x => x.Id == number);
        break;
      }

      var bookService = new DataBase.Services.BookService(appDbContext);
      var books = bookService.GetAllBooksOfAutor(autor);
      if (books.Count == 0)
      {
        Console.WriteLine("У данного автора нет ни одной книги!");
      }
      else
      {
        Console.WriteLine("Найденные книги автора:");
        foreach (var book in books)
        {
          Console.WriteLine($"{book.Id}. {book.Name} - {book.PrintRun}");
        }
      }

      Console.WriteLine();
    }

    /// <summary>
    /// Запрашивает издательство и выводит все его книги в консоль.
    /// </summary>
    static private void PrintAllBooksByPublishingHouse(AppDbContext appDbContext)
    {
      var publishingHouseService = new DataBase.Services.PublishingHouseService(appDbContext);
      var publishingHouses = publishingHouseService.GetAllPublishingHouses();

      PublishingHouseModel publishingHouse = null;

      foreach (var item in publishingHouses)
      {
        Console.WriteLine($"{item.Id}. {item.Name} ");
      }

      Console.Write("Ввведите номер издательства:");
      while (true)
      {
        var input = Console.ReadLine();
        if (!int.TryParse(input, out int number) || !publishingHouses.Any(x => x.Id == number))
        {
          Console.Write("Введите корректный номер издательсва:");
          continue;
        }

        publishingHouse = publishingHouses.First(x => x.Id == number);
        break;
      }

      var bookService = new DataBase.Services.BookService(appDbContext);
      var books = bookService.GetAllBooksOfPublishingHouse(publishingHouse);
      if (books.Count == 0)
      {
        Console.WriteLine("У данного издательства нет ни одной книги!");
      }
      else
      {
        Console.WriteLine("Найденные книги издателсьва:");
        foreach (var book in books)
        {
          Console.WriteLine($"{book.Id}. {book.Name} - {book.PrintRun}");
        }
      }
      Console.WriteLine();
    }
  }
}

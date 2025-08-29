namespace FileWordSearcher
{
  internal class Program
  {
    static async Task Main(string[] args)
    {
      while (true)
      {
        string? path = DirectoryService.GetDirectoryPath();
        if (string.IsNullOrEmpty(path))
        {
          return;
        }

        if (!DirectoryService.CheckDirectoryPath(path))
        {
          continue;
        }

        var (empty, files) = DirectoryService.GetFilesFromDirectory(path);
        if (empty)
        {
          continue;
        }

        string word = GetWordFromConsole();

        await SearchManager.SearchWordsInFiles(files, word);
      }
    }

    /// <summary>
    /// Возвращает слово, которое вводится в консоли.
    /// </summary>
    /// <returns></returns>
    static string GetWordFromConsole()
    {
      while (true)
      {
        Console.Write("Введите слово для поиска (для выхода отправьте пустое сообщение): ");
        string? word = Console.ReadLine();
        if (string.IsNullOrEmpty(word))
        {
          Console.Write("Слово не может быть пустым! Попробуйте ещё раз");
          continue;
        }
        else
        {
          return word;
        }
      }
    }
  }
}

namespace FileWordSearcher
{

  /// <summary>
  /// Класс для работы с директориями.
  /// </summary>
  internal static class DirectoryService
  {
    /// <summary>
    /// Запрашивает у пользователя путь к директории с файлами.
    /// </summary>
    /// <returns>Путь к директории.</returns>
    internal static string? GetDirectoryPath()
    {
      Console.Write("Введите полный путь к директории с файлами (для выхода отправьте пустое сообщение): ");
      return Console.ReadLine();
    }

    /// <summary>
    /// Проверяет существование директории по указанному пути.
    /// </summary>
    /// <param name="path">Путь к файлу.</param>
    /// <returns>true - директория существует, false - директории нет.</returns>
    internal static bool CheckDirectoryPath(string? path)
    {
      if (!Directory.Exists(path))
      {
        Console.WriteLine("Указанная директория не существует. Попробуйте снова.");
        return false;
      }

      return true;
    }

    /// <summary>
    /// Возвращает статус пустоты директории и список файлов в ней.
    /// </summary>
    /// <param name="path">Путь к директории.</param>
    /// <returns>Пути к каждому файлу из папки.</returns>
    internal static (bool Empty, List<string> files) GetFilesFromDirectory(string path)
    {
      var files = Directory.GetFiles(path).ToList();
      if (files.Count == 0)
      {
        Console.WriteLine($"В директории {path} нет файлов. Попробуйте снова.");
        return (true, files);
      }

      return (false, files);
    }
  }
}

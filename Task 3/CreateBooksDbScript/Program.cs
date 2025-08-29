using CreateBooksDbScript.DataBase;

namespace CreateBooksDbScript
{
  internal class Program
  {
    static void Main(string[] args)
    {
      new AppDbContext();
      Console.WriteLine($"Путь к базе данных:{AppDbContext.DbPath}");
    }
  }
}

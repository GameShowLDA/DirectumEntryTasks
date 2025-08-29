using CreateBooksDbScript.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateBooksDbScript.DataBase.Services
{
  internal class PublishingHouseService
  {
    /// <summary>
    /// Класс для управления БД.
    /// </summary>
    private readonly AppDbContext _context;

    public PublishingHouseService(AppDbContext context)
    {
      _context = context;
    }

    /// <summary>
    /// Получает все издательства из базы данных.
    /// </summary>
    /// <returns>Список авторов.</returns>
    public List<PublishingHouseModel> GetAllPublishingHouses() => _context.PublishingHouses.ToList();
  }
}

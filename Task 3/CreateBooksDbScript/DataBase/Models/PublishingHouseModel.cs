using System.ComponentModel.DataAnnotations;

namespace CreateBooksDbScript.DB.Models
{
  /// <summary>
  /// Модель издателсьва.
  /// </summary>
  internal class PublishingHouseModel
  {
    /// <summary>
    /// Уникальный номер.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Наимаенование издательства.
    /// </summary>
    public string Name { get; set; } = string.Empty;
  }
}

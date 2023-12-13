using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KrMicro.Core.Models.Abstraction;

namespace KrMicro.MasterData.Models;

[Table("Categories")]
public class Category : BaseModelWithAuditAndTracking
{
    [Required] [Column("Name")] public string Name { get; set; } = string.Empty;
    [Column("IsMenu")] public bool IsMenu { get; set; } = false;

    public List<Product> Products { get; set; } = new();
}
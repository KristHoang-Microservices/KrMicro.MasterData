using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KrMicro.Core.Models.Abstraction;

namespace KrMicro.MasterData.Models;

[Table("Categories")]
public class Category : BaseModelWithAuditAndTracking
{
    [Required] [Column("name")] public string Name { get; set; } = string.Empty;
}
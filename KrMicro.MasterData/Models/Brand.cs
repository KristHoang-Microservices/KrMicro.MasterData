using System.ComponentModel.DataAnnotations.Schema;
using KrMicro.Core.Models.Abstraction;

namespace KrMicro.MasterData.Models;

[Table("Brands")]
public class Brand : BaseModelWithAuditAndTracking
{
    [Column("Name")] public string Name { get; set; } = string.Empty;
    [Column("Description")] public string? Description { get; set; }
    [Column("ImageUrl")] public string? ImageUrl { get; set; }
}
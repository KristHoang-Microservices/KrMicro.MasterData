using System.ComponentModel.DataAnnotations.Schema;
using KrMicro.Core.Models.Abstraction;

namespace KrMicro.MasterData.Models;

[Table("Brands")]
public class Brand : BaseModelWithAuditAndTracking
{
    [Column("name")] public string Name { get; set; } = string.Empty;
    [Column("description")] public string? Description { get; set; }
    [Column("image_url")] public string? ImageUrl { get; set; }
}
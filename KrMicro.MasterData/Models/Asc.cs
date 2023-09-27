using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using KrMicro.Core.Models.Abstraction;

namespace KrMicro.MasterData.Models;

[Table("Asc")]
public class Asc : BaseModelWithAuditAndTracking
{
    [Required] [Column("Name")] public string Name { get; set; } = string.Empty;

    [Column("Address")]
    [StringLength(150)]
    public string? Address { get; set; }

    [Column("Hotline")]
    [RegexStringValidator(@"/(03|05|07|08|09|01[2|6|8|9])+([0-9]{8})\b/")]
    public string? Hotline { get; set; }
}
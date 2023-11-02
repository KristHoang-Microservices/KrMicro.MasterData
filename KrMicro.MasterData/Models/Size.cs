using System.ComponentModel.DataAnnotations.Schema;
using KrMicro.Core.Models.Abstraction;

namespace KrMicro.MasterData.Models;

[Table("Sizes")]
public class Size : BaseModelWithAuditAndTracking
{
    [Column("SizeCode")] public string SizeCode { get; init; } = string.Empty;

    public List<ProductSize> ProductSizes { get; set; }
}
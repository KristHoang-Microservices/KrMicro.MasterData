using System.ComponentModel.DataAnnotations.Schema;
using KrMicro.Core.Models.Abstraction;

namespace KrMicro.MasterData.Models;

[Table("Discounts")]
public class Discount : BaseModelWithAuditAndTracking
{
    [Column("name")] public string Name { get; set; } = string.Empty;
    [Column("discount_percent")] public decimal DiscountPercent { get; set; }
}
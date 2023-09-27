using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using KrMicro.Core.Models.Abstraction;

namespace KrMicro.MasterData.Models;

[Table("DeliveryVendors")]
public class DeliveryVendor : BaseModelWithAuditAndTracking
{
    [Required] [Column("Name")] public string Name { get; set; } = string.Empty;
    [Required] public decimal Fee { get; set; } = 0;
}
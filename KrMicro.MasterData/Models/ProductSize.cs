using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KrMicro.Core.Models.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace KrMicro.MasterData.Models;

[Table("ProductSize")]
public class ProductSize : NoIdWithAuditAndTracking
{
    [ForeignKey("SizeId")] public short SizeId { get; set; }
    [ForeignKey("ProductId")] public short ProductId { get; set; }
    [Column("Stock")] public int Stock { get; set; }

    [Required]
    [Column("Price")]
    [Precision(16, 2)]
    public decimal Price { get; set; }

    public Size Size { get; set; }
    public Product Product { get; set; }
}
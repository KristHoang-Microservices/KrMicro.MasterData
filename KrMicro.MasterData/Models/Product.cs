using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using KrMicro.Core.Models.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace KrMicro.MasterData.Models;

[Table("Products")]
public class Product : BaseModelWithAuditAndTracking
{
    [Required] [Column("Name")] public string Name { get; set; } = string.Empty;

    [Required]
    [Column("Price")]
    [Precision(16, 2)]
    public decimal Price { get; set; }

    [Column("Description")] public string? Description { get; set; }

    public short? BrandId { get; set; }
    [ForeignKey("BrandId")] public Brand? Brand { get; set; }

    public short? CategoryId { get; set; }
    [ForeignKey("CategoryId")] public Category? Category { get; set; }
    
    [Column("ImportFrom")] public string? ImportFrom { get; set; }

    [Column("ReleaseYear")]
    [IntegerValidator(MinValue = 1000)]
    public short? ReleaseYear { get; set; }

    public int Stock { get; set; } = 0;

    [Column("FragranceDescription")] public string? FragranceDescription { get; set; }
    [Column("StyleDescription")] public string? Style { get; set; }
    [Column("ImageUrls")] public string? ImageUrls { get; set; }
}
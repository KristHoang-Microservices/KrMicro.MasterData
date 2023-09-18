using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using KrMicro.Core.Models.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace KrMicro.MasterData.Models;

[Table("Products")]
public class Product : BaseModelWithAuditAndTracking
{
    [Required] [Column("name")] public string Name { get; set; } = string.Empty;

    [Required]
    [Column("price")]
    [Precision(16, 2)]
    public decimal Price { get; set; }

    [Column("description")] public string? Description { get; set; }

    [ForeignKey("brand_id")] public virtual Brand? Brand { get; set; }

    [ForeignKey("category_id")] public virtual Category? Category { get; set; }

    [Column("import_from")] public string? ImportFrom { get; set; }

    [Column("release_year")]
    [IntegerValidator(MinValue = 1000)]
    public short? ReleaseYear { get; set; }

    [Column("fragrance_description")] public string? FragranceDescription { get; set; }
    [Column("style_description")] public string? Style { get; set; }
    [Column("image_urls")] public string? ImageUrls { get; set; }
}
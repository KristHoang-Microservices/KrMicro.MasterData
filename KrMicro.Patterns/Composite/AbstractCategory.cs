using KrMicro.MasterData.Models;

namespace KrMicro.Patterns.Composite;

public abstract class AbstractCategory
{
    protected string Name { get; set; } = string.Empty;
    protected bool IsMenu { get; set; }
    public abstract List<Product> GetChildProducts();
    public abstract List<AbstractCategory> GetChildCategories();
}
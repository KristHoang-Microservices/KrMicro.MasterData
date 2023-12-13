using KrMicro.MasterData.Models;

namespace KrMicro.Patterns.Composite;

public class ProductCategory : AbstractCategory
{
    private readonly List<Product> _products;

    public ProductCategory(List<Product> products)
    {
        _products = products;
    }

    public override List<Product> GetChildProducts()
    {
        return _products;
    }

    public override List<AbstractCategory> GetChildCategories()
    {
        return new List<AbstractCategory>();
    }
}
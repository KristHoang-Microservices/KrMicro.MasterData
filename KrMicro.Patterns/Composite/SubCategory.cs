using KrMicro.MasterData.Models;

namespace KrMicro.Patterns.Composite;

public class SubCategory : AbstractCategory
{
    private readonly List<AbstractCategory> _categories;
    private readonly List<Product> _products;

    public SubCategory(List<AbstractCategory> categories, List<Product> products)
    {
        _categories = categories;
        _products = products;
    }

    public override List<Product> GetChildProducts()
    {
        return _categories.SelectMany(category => category.GetChildProducts()).Concat(_products).ToList();
    }

    public override List<AbstractCategory> GetChildCategories()
    {
        return _categories.SelectMany(x => x.GetChildCategories()).ToList();
    }
}
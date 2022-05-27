using System.Reflection.Metadata;

namespace MethodsAndProperties;

public class SalesList
{
    private List<Sale> _sales = new();

    public IEnumerable<Sale> EnumerateItems()
    {
        foreach (var item in _sales)
        {
            yield return item;
        }
    }

    public SalesList AddSale(Sale item)
    {
        _sales.Add(item);
        return this;
    }

    //Return Value Tuples
    public (string CustomerName, decimal TotalSpent, int NSales) GetHighestValueCustomer()
    {
        var customerBySpend = from transaction in _sales
                              group transaction by transaction.Customer
                              into grouping
                              let totalValue = grouping.Select(x => x.Value).Sum()
                              let salesCount = grouping.Count()
                              orderby totalValue descending
                              select (grouping.Key.Name, totalValue, salesCount);

        return customerBySpend.First();
    }

    //Use out params
    public string GetHighestValueCustomer(out decimal totalSpent, out int nSales)
    {
        var customerBySpend = from transaction in _sales
                              group transaction by transaction.Customer
                              into grouping
                              let totalValue = grouping.Select(x => x.Value).Sum()
                              let salesCount = grouping.Count()
                              orderby totalValue descending
                              select (grouping.Key.Name, totalValue, salesCount);

        var result = customerBySpend.First();
        totalSpent = result.totalValue;
        nSales = result.salesCount;
        return result.Name;
    }
}
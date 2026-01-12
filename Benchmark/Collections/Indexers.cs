namespace Benchmark.Collections;

using static System.DayOfWeek;
public class CatalogItem
{
    private readonly string[] _weekDeals = ["10% OFF", "20% OFF"];
    
    public decimal Price { get; set; }
    
    public string this[DayOfWeek day] => GetDailyDeal(day);

    private string GetDailyDeal(DayOfWeek day)
    {
        return _weekDeals[(int)day % 2];
    }
    
}

public class Teste()
{
    public void testes()
    {
         var ae = new CatalogItem();

         ae.Price = 12;
         var sae = ae[Saturday];
         var bbe = ae.Price;
    }
   
    
}
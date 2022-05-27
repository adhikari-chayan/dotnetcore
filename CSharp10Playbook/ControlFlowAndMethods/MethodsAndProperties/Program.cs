using MethodsAndProperties;

//invalid values
//CookieCustomer customer = new(0,"");

//Console.WriteLine(customer);

//char firstCh = customer.NameFirstChar;
//Console.WriteLine($"Customer's name starts with {firstCh}");

CookieCustomer pluralsight = new(1, "Pluralsight");
CookieCustomer simon = new(2, "Simon");
CookieCustomer browserRobot = new(3, "Browser Robot");

//Fluent coding style: Use the return value from each operation to chain into the next operation
SalesList sales = new();
sales.AddSale(new(simon, 200))
     .AddSale(new(pluralsight, 80))
     .AddSale(new(simon, 50))
     .AddSale(new(browserRobot, 500))
     .AddSale(new(pluralsight, 1000))
     .AddSale(new(browserRobot, 50))
     .AddSale(new(pluralsight, 20));

//Fluent coding in Linq
var highValueSales = sales.EnumerateItems()
                          .Where(sale=> sale.Value >100)
                          .OrderBy(sale=>sale.Customer.Name);


//This is tuple deconstruction
(string name, decimal totalValue, int nSales) = sales.GetHighestValueCustomer();

Console.WriteLine("Highest spender:");
Console.WriteLine($"{name} spent {totalValue} in {nSales} purchases");

//highest will be of type ValueTuple<string, decimal, int>
var highest = sales.GetHighestValueCustomer();

Console.WriteLine("Highest spender:");
Console.WriteLine($"{highest.CustomerName} spent {highest.TotalSpent} in {highest.NSales} purchases");

//Consume method using out param
string customerName = sales.GetHighestValueCustomer(out decimal totalAmount, out int nTransactions);
Console.WriteLine("Highest spender:");
Console.WriteLine($"{customerName} spent {totalAmount} in {nTransactions} purchases");

bool isEligible = BusinessRules.EligibleForVoucher(nTransactions, in totalAmount);
Console.WriteLine($"Is {customerName} eligible for voucher? {isEligible}");

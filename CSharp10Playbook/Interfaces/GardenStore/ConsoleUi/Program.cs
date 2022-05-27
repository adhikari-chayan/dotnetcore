using BusinessObjects;
using DataAccess;

var repository = new ClientRepository("connection string");
GardenClient client = repository.GetClientFromId(1);

client.AddToCart("Carnations");
client.AddToCart("Roses");

ConsoleLogger logger = new ConsoleLogger();

client.Logger = logger;

client.LogMyself();

client.SaveCart();

//DisplayClient(client);

//void DisplayClient(GardenClient client)
//{
//	Console.WriteLine(client.Name);
//	foreach (string item in client.ShoppingCart)
//		Console.WriteLine($" In cart: {item}");
//	Console.WriteLine();
//}

//Console.WriteLine($"Client.Name = {client.Name}");
////Console.WriteLine($"Client.CurrentState = {client.CurrentState}");
//Console.WriteLine();

//ILoggable clientAsLoggable = client as ILoggable;
//Console.WriteLine($"ILoggable.Name = {clientAsLoggable.Name}");
//Console.WriteLine($"ILoggable.CurrentState = {clientAsLoggable.CurrentState}");
//Console.WriteLine();


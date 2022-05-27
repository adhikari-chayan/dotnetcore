using System.Text;

namespace BusinessObjects;

//This is a plain business object with no other dependencies
public class GardenClient : ILoggable
{
    private readonly IClientRepository _repository;

    public int Id { get; }

    public string Name { get; }

    public List<string> ShoppingCart { get; } = new();

    //This property is another example of dependency injection using an interface
    public ILogger? Logger { get; set; }

    public void LogMyself()
        => Logger?.LogState(this);

    //This says that the member is exclusively associated with the interface
    // Access modifiers are not permitted - interface members are implicitly public
    // Explicit interface members: Can only be accessed from variables that are typed to the interface(ILoggable clientAsLoggable = client as ILoggable;)
    string ILoggable.Name => $"client Id = {Id}";

    //The ILoggable members are not core functionality of GardenClient. So converting this property as well to exclusively associated with the interface ILoggable
    string ILoggable.CurrentState
    {
        get
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Id = {Id}, Name = {Name}, {ShoppingCart.Count} purchases");
            foreach (var purchase in ShoppingCart)
            {
                sb.AppendLine($" purchased:{purchase}");
            }

            return sb.ToString();
        }
    }

    public GardenClient(int id, string name, IClientRepository repository)
    {
        Id = id;
        Name = name;
        //This is bad design! It makes the business object dependent on external database details
        //var repository = new ClientRepository("connection-string");
        _repository = repository;
    }

    public void AddToCart(string itemName)
    {
        ShoppingCart.Add(itemName);
    }

    public void SaveCart()
    {
        Logger?.TryLogMethodCall(this, nameof(SaveCart));
        _repository.PersistCart(this);
    }
}

//Define interfaces in the lowest level project where they might be required
//Even if concrete classes must be defined further up
//Then do dependency injection with the interfaces
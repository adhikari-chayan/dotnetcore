namespace MethodsAndProperties;

public class CookieCustomer
{
    public int Id { get; }//must be > 0

    //Customers are allowed to change name. So it should be settable. But auto-property won't do data validation
   // public string Name { get; }//must contain something

    private string _name;
    public string Name
    {
        get => _name;
        set
        {
            ValidateName(value, nameof(Name));
            _name = value;
        }
    }

    public string? Notes { get; set; }

    public char NameFirstChar => Name[0];

    public CookieCustomer(int id, string name, string? notes = null)
    {
        //These are guard clauses
        //Exception messages are very clear about the nature of the issue
        
        //if (string.IsNullOrEmpty(name))
        //{
        //    throw new ArgumentException("Customer name cannot be null or whitespace", nameof(name));
        //}

        //if (id <= 0)
        //{
        //    throw new ArgumentException($"Customer ID must be > 0. Actual value was: {id}", nameof(id));
        //}

        //Improving the guard clauses
        //Here two ways of writing guard clauses is shown. For code clarity, avoid mixing different guard clause techniques
        ValidateName(name, nameof(name));

        if (id <=0 )
        {
            throw BuildInvalidIdException(id, nameof(id));
        }

        Id = id;
        _name = name;
        Notes = notes;
    }

    private ArgumentException BuildInvalidIdException(int id, string paramName)
        => new ArgumentException($"Customer ID must be > 0. Actual value was: {id}", paramName);
    

    private void ValidateName(string name, string paramName)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("Customer name cannot be null or whitespace", paramName);
        }
    }

    public override string ToString()
        => $"Customer Id = {Id}, Name = {Name}";
}

/* -Auto-property is simplest - so choose that if possible
   -Auto-properties are only possible if there is no logic
   -Expression-bodied property works when there is no backing field or setter
*/
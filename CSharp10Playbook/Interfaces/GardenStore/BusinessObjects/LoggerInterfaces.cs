namespace BusinessObjects;


public interface ILogger
{
    void LogState(ILoggable source);

    //Default interface member implementation. Covers if any interface implement haven's implemented this member
    void LogMethodCall(ILoggable source, string methodName)
        => throw new NotImplementedException(nameof(LogMethodCall));



    bool CanLogMethodCall => false;

    //This will log a method call if this instance supports it
    //This logic allows us to usefully start supporting this feature -  even if it's only on some loggers
    bool TryLogMethodCall(ILoggable source, string methodName)
    {
        bool canLog = CanLogMethodCall;
        if(canLog)
            LogMethodCall(source, methodName);
        return canLog;
    }
}

public interface ILoggable
{
    //Should return a string that uniquely identifies the object being logged
    string Name { get; }

    //Should return a string representation of current state of the object
    string CurrentState { get; }
}

//Instance state is not allowed in interfaces
//This facility is there for fallback logic anf nothing fancy

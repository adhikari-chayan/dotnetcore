namespace ControlFlow;

public class FolderProcessor
{
    //This loop mixes the loop iteration logic with processing the items it iterates over
    //We should seperate those in order to process the results the way we need(Reversed)
    public static void DisplayParentNames_While(string filePath)
    {
        var folder = new DirectoryInfo(Path.GetDirectoryName(filePath)!);
        while (folder is not null)
        {
            Console.WriteLine(folder.Name);
            folder = folder.Parent;
        }
    }

    //Some overhead of creating the List
    public static List<string> GetParentNames_While(string filePath)
    {
        var results = new List<string>();

        var folder = new DirectoryInfo(Path.GetDirectoryName(filePath)!);
        while (folder is not null)
        {
            results.Add(folder.Name);
            folder = folder.Parent;
        }

        return results;
    }

    //Simpler/more general solution: Return a plain sequence
    //yield return passes the item back to the caller, and continues executing the loop when the caller requests the next item
    //This loop design leaves it to the caller to decide how many items are required and in what order
    public static IEnumerable<string> EnumParentNames_While(string filePath)
    {
        var folder = new DirectoryInfo(Path.GetDirectoryName(filePath)!);
        while (folder is not null)
        {
            yield return folder.Name;
            folder = folder.Parent;
        }
    }

    //Functionally, for and while loops do the same thing; for just adds syntactic sugar
    //Advantage: Puts all loop control logic in one place;
    //Disadvantage: Other devs may not be familiar with using for loop like this
    public static IEnumerable<string> EnumParentNames_For(string filePath)
    {
        for (var folder = new DirectoryInfo(Path.GetDirectoryName(filePath)!); folder is not null; folder = folder.Parent)
        {
            yield return folder.Name;
        }
    }

    //while amd for test if the loop should run before running it the first time
    //do only tests after the loop has run for the first time
    public static IEnumerable<string> EnumParentNames_Do(string filePath)
    {
        var folder = new DirectoryInfo(Path.GetDirectoryName(filePath)!);
        do
        {
            yield return folder.Name;
            folder = folder.Parent;
        } while (folder is not null);
    }
}

/* For loops with non-trivial iteration logic:
    - Consider letting the loop just return results(for example with yield return)
    - Let the caller deal with processing the loop results
*/
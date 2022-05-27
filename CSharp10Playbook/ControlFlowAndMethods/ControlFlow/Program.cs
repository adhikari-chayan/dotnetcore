using System.Reflection;
using ControlFlow;

//List<string> languages = new() {"C#", "F#", "VB", "C++", "Python"};
//Sequences.DisplayListWithIndex_ForEach(languages);

string filePath = Assembly.GetEntryAssembly()!.Location;

Console.WriteLine($"Entry assembly is {Path.GetFileName(filePath)}");
Console.WriteLine("Folders are: ");

//FolderProcessor.DisplayParentNames_While(filePath);

foreach (string folder in FolderProcessor.EnumParentNames_While(filePath).Reverse())
{
    Console.WriteLine(folder);
}


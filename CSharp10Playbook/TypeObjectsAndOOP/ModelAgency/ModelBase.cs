namespace Pluralsight.CShPlaybook.Oop;

public class ModelBase
{
    private string _otherInfo = "";
	public string Name { get; }
	public int Id { get; }
	public IPhotoProvider PhotoProvider { get; }

	public ModelBase(int id, string name, string photoFileName)
	{
		Id = id;
		Name = name;
		
        //This should not be the responsibility for ModelBase. The solution: A factory class
        //PhotoProvider = File.Exists(DataFileFinder.GetFilePath(photoFileName)) ? new ModelPhotoProvider(photoFileName) : MissingPhotoProvider.Instance;

        //using the factory
        PhotoProvider = ModelPhotoProvider.PhotoProviderFactory.Create(photoFileName);
    }

	public override string ToString() => Name;
}


/* Ways to initialize fields or auto-properties
     * Use an initializer like _otherInfo
     * Initialize in constructor
     * Field initializers are always executed before instance constructors. That means we can use values of field initializers in constructors
*/


namespace Pluralsight.CShPlaybook.Oop;

public class CanineModel : ModelBase
{
	public string CompanionHuman { get; }

	public CanineModel (int id, string name, string companionHuman)
		: base (id, name, MakePhotoFileName(id, name))
	{		
		CompanionHuman = companionHuman;
	}

	//MakePhotoFileName is static because when we pass it to base constructor at that point the sub class(CanineModel instance) is not instantiated. So, we can't call any instance members of that class.
	private static string MakePhotoFileName(int id, string name) => $"Dog_{id}_{name}.jpg";
}
/* The Initialization order-
    - Initializers --> can use only constants and statics
    - Base constructor --> can use initializer data
    - Derived constructor --> can use all base class data
 */

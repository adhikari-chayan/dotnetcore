namespace Pluralsight.CShPlaybook.Oop
{
	public class MissingPhotoProvider : IPhotoProvider
	{
		private Lazy<Image> _missingPhotoImage;

		//This is the only place that MissingPhotoProvider is ever instantiated
		//Static Initializer is only run once - so only one instance of MissingPhotoProvider can ever be created
		public static MissingPhotoProvider Instance { get; } = new ();

		//if all constructors are private, nothing outside this type can instantiate it
		private MissingPhotoProvider()
		{
			string filePath = DataFileFinder.GetFilePath("Missing.jpg");
			_missingPhotoImage = new Lazy<Image>(() => Image.FromFile(filePath));
		}

		public Image GetPhoto() => _missingPhotoImage.Value;
	}

	//It would waste resources if multiple canine models loaded their own copies of the missing image

}

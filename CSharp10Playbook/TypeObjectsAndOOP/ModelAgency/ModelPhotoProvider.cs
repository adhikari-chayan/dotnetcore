namespace Pluralsight.CShPlaybook.Oop;

public interface IPhotoProvider
{
	//System.Drawing.Image stores an image as .bmp, or .jpg, etc.
	Image? GetPhoto();
}

public class ModelPhotoProvider : IPhotoProvider
{
	//private Image? _photo;
    private Lazy<Image?> _photo;
    private string _filePath;

    // We need the ModelPhotoProvider constructor to be invisible to everything except the factory. Hence, constructor is made private
    // We make the PhotoProviderFactory nested class to access the private member
    private ModelPhotoProvider(string fileName)
	{
		//string filePath = DataFileFinder.GetFilePath(fileName);
        // if (File.Exists(filePath))
			//_photo = Image.FromFile(filePath); //This image is loaded at construction time. But we don't know if anything will ever call GetPhoto()

      _filePath = DataFileFinder.GetFilePath(fileName);
      //The lambda tells the system what it needs to do the first time the image is requested
      _photo = new Lazy<Image?>(() => File.Exists(_filePath) ? Image.FromFile(_filePath) : null);

    }

    //public Image? GetPhoto => _photo;

    //This is good lazy-loading solution - but only for single threaded code
    //What if multiple threads call this method before the photo has been loaded-> The threads will all try to load the image at the same time

    //public Image? GetPhoto()
    //{
    //    if (_photo is null && File.Exists(_filePath))
    //        _photo = Image.FromFile(_filePath);

    //    return _photo;
    //}

    //Lazy<T>.Value runs the lambda to get the value the first time it's invoked, and caches the value
    //Subsequent calls return the cached value
    //It is thread safe but thread safety can  be switched off
    public Image? GetPhoto()
      => _photo.Value;


    //Nested types can see the container's private members. But the container can't see the nested type's private members
    public static class PhotoProviderFactory
    {
        public static IPhotoProvider Create(string fileName)
        {
            string filePath = DataFileFinder.GetFilePath(fileName);
            if (File.Exists(filePath))
                return new ModelPhotoProvider(fileName);
            else
                return MissingPhotoProvider.Instance;
        }

    }

}


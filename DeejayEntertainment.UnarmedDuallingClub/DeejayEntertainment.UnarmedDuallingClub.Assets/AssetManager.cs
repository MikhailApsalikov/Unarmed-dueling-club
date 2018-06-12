using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace DeejayEntertainment.UnarmedDuallingClub.Assets
{
    public class AssetManager
    {
	    private readonly string basePath;
		private readonly Dictionary<string, Image> cache = new Dictionary<string, Image>();

	    public AssetManager(string basePath)
	    {
		    this.basePath = basePath;
	    }

	    public Image GetImageByPath(string path)
	    {
		    if (cache.ContainsKey(path))
		    {
			    return cache[path];
		    }
		    Image result = Image.FromFile(Path.Combine(basePath, path));
		    cache[path] = result;
		    return result;
	    }
	}
}

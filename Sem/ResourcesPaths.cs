using System.IO;

namespace Sem
{
	public static class ResourcesPaths
	{
		public static string GetPersonPhotoPath(object s) => GetPath((int) s, "PeoplePhotos");

		public static string GetArticleImagePath(object s) => GetPath((int) s, "ArticleImages");

		public static string GetUserImagesPath(object s) => GetPath((int) s, "UserImages");

		private static string GetPath(int s, string folder)
		{
			var a = Directory.GetCurrentDirectory();
			var path = $"Resources/{folder}/{s}.jpg";
			var path2 = "wwwroot/" + path;
			return !File.Exists(path2) ? "imgs/dog.png" : path;
		}
	}
}
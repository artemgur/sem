using System.IO;
using System.Linq;

namespace Sem
{
	public static class ResourcesPaths
	{
		public static string GetPersonPhotoPath(object s) => GetPath((int) s, "PeoplePhotos");

		public static string GetArticleImagePath(object s) => GetPath((int) s, "ArticleImages");

		public static string GetUserImagesPath(object s) => GetPath((int) s, "UserImages");

		private static string GetPath(int s, string folder)
		{
			var file = Path.GetFileName(Directory.GetFiles(@$"wwwroot/Resources/{folder}/", s + ".*").FirstOrDefault());
			if (file == null)
				return "/imgs/dog.png";
			return $"/Resources/{folder}/" + (string) file;
		}
	}
}
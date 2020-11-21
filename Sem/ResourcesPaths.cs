using System;
using Database;

namespace Sem
{
	public static class ResourcesPaths
	{
		public static string GetPersonPhotoPath(object s)
		{
			//e.Values.TryGetValue("photo", out var s);
			//var s = e.Values["photo"];
			return s is DBNull ? "imgs/dog.png" : $"Resources/PeoplePhotos/{s}.jpg";
		}

		public static string GetArticleImagePath(object s)
		{
			//e.Values.TryGetValue("photo", out var s);
			//var s = e.Values["photo"];
			return s is DBNull ? "imgs/dog.png" : $"Resources/ArticleImages/{s}.jpg";
		}

		public static string GetUserImagesPath(object s)
		{
			//e.Values.TryGetValue("photo", out var s);
			//var s = e.Values["photo"];
			return s is DBNull ? "imgs/dog.png" : $"Resources/UserImages/{s}.jpg";
		}
	}
}
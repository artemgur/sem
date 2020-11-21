using System;
using Database;

namespace Sem
{
	public static class ResourcesPaths
	{
		public static string GetPersonPhotoPath(Entity e)
		{
			//e.Values.TryGetValue("photo", out var s);
			var s = e.Values["photo"];
			return s is DBNull ? "imgs/dog.png" : $"Resources/PeoplePhotos/{s}.jpg";
		}

		public static string GetArticleImagePath(Entity e)
		{
			//e.Values.TryGetValue("photo", out var s);
			var s = e.Values["photo"];
			return s is DBNull ? "imgs/dog.png" : $"Resources/ArticleImages/{s}.jpg";
		}

		public static string GetUserImagesPath(Entity e)
		{
			//e.Values.TryGetValue("photo", out var s);
			var s = e.Values["photo"];
			return s is DBNull ? "imgs/dog.png" : $"Resources/UserImages/{s}.jpg";
		}
	}
}
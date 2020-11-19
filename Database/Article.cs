using System.Collections.Generic;
using static Database.General;

namespace Database
{
	public static class Article
	{
		public static IAsyncEnumerable<Entity> SearchByName(string name, int offset, int number) =>
			Select("articles_with_tags", $"name LIKE '%{name}%'", offset, number/*, "date"*/);

		// /// Returns the link to article, that was passed as parameter!
		// public static Entity ToArticleWithTags(Entity article)
		// {
		// 	var tags = Select("tags_article", $"article_id={article.Values["id"]}");
		// 	article.Values["tags"] = tags;
		// 	return article;
		// }
		
		//public static IEnumerable<Entity> GetArticles()

		public static IAsyncEnumerable<Entity> Get(int offset, int number) =>
			Select("articles_with_tags", offset, number);
		
		// public static IEnumerable<Entity>
	}
}
﻿using System.Collections.Generic;
using static Database.General;

namespace Database
{
	public static class People
	{
		// /// Returns the link to article, that was passed as parameter!
		// public static Entity ToArticleWithTags(Entity article)
		// {
		// 	var tags = Select("tags_article", $"article_id={article["id"]}");
		// 	article["tags"] = tags;
		// 	return article;
		// }
		
		//public static IEnumerable<Entity> GetArticles()

		public static IAsyncEnumerable<Entity> Get(int offset = 0, int number = -1) =>
			Select("people_with_tags", offset, number);//TODO change back to people_with_tags
		
		public static IAsyncEnumerable<Entity> SearchByName(string name, int offset = 0, int number = -1) =>
			Select("people_with_tags", $"name LIKE '%{name}%'", offset, number/*, "date"*/);

		public static IAsyncEnumerable<Entity> SearchByNameAndTag(string name, string tag, int offset = 0,
			int number = -1) => Select($"select_people_by_name_and_tag('%{name}%', '{tag}')", offset, number);

		// public static IEnumerable<Entity>
	}
}
using Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Sem
{
	public static class FavoriteArticles
	{
		public static void Manage(IApplicationBuilder app)
		{
			app.Run(async context =>
			{
				var id = context.Session.GetInt32("user_id");
				if (id == null)
					context.Response.Headers.Add("status", "not_registered");
				else if (context.Request.Headers["action"] == "add")
					Add(context, (int) id);
				else
					Remove(context, (int) id);
			});
		}

		private static void Remove(HttpContext context, int id)
		{
			var articleId = int.Parse(context.Request.Headers["article_id"].ToString());
			Article.RemoveFavoriteArticle(id, articleId);
			context.Response.Headers.Add("status", "success");
		}

		private static void Add(HttpContext context, int id)
		{
			var articleId = int.Parse(context.Request.Headers["article_id"].ToString());
			Article.AddFavoriteArticle(id, articleId);
			context.Response.Headers.Add("status", "success");
		}
	}
}
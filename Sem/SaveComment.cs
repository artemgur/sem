using System.Web;
using Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Sem
{
	public static class SaveComment
	{
		public static void Save(IApplicationBuilder app)
		{
			app.Run(async context =>
			{
				var id = context.Session.GetInt32("user_id");
				if (id == null)
				{
					context.Response.Headers.Add("status", "not_registered");
					return;
				}
				var debateId = context.Request.Headers["debate_id"];
				var text = HttpUtility.UrlDecode(context.Request.Headers["text"]);
				var opinion = context.Request.Headers["opinion"];
				await Comments.Save((int) id, debateId, text, opinion);
			});
		}
	}
}
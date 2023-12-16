using System.IO;
using System.Web;
using Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Sem
{
	public class CreateDebate
	{
		public static void Create(IApplicationBuilder app)
		{
			app.Run(async context =>
			{
				var id = context.Session.GetInt32("user_id");
				if (id == null)
				{
					context.Response.Headers.Add("status", "not_registered");
					return;
				}
				var title = HttpUtility.UrlDecode((string)context.Request.Headers["title"]);
				var text = HttpUtility.UrlDecode((string)context.Request.Headers["text"]);
				using var r = new StreamReader(context.Request.Body);
				var s = await r.ReadToEndAsync();
				var tags = JsonConvert.DeserializeObject<string[]>(s/*.Headers["tags"]*/);
				context.Response.Headers.Add("status", "success");
				context.Response.Headers.Add("id", (await Debates.Create(title, text, tags, (int)id)).ToString());
			});
		}
	}
}
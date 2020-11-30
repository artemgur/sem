using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Sem
{
	public static class SaveImage
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
				var files = Directory.GetFiles(@"wwwroot\Resources\UserImages\", id + ".*");
				foreach (var x in files)
					File.Delete(x);
				var extension = context.Request.ContentType.Split('/')[1];
				var fileStream = File.Open(@$"wwwroot\Resources\UserImages\{id}.{extension}", FileMode.Create);
				await context.Request.Body.CopyToAsync(fileStream);
				context.Request.Body.Close();
				fileStream.Close();
			});
		}
	}
}
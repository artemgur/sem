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
				var files = Directory.GetFiles(@"wwwroot/Resources/UserImages/", id + ".*");
				foreach (var x in files)
					File.Delete(x);
				//var filename = context.Request.Headers["filename"];
				var file = context.Request.Form.Files.GetFile("image");
				//var a = file.ContentType;
				var extension = Path.GetExtension(file.FileName);
				// var extension = "jpg";//context.Request.ContentType.Split('/')[1];
				var fileStream = File.Open(@$"wwwroot\Resources\UserImages\{id}{extension}", FileMode.Create);
				await file.CopyToAsync(fileStream);
				//context.Request.Body.Close();
				fileStream.Close();
			});
		}
	}
}
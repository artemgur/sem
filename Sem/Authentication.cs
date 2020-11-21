using System.Threading.Tasks;
using Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Sem
{
	public static class Authentication
	{
		public static void Authenticate(IApplicationBuilder app)
		{
			app.Run(async context =>
			{
				var request = context.Request;
				if (request.Headers.ContainsKey("register"))
					await Register(context);
				else
					await LogIn(context);
			});
		}

		private static async Task LogIn(HttpContext context)
		{
			var username = context.Request.Headers["username"];
			var password = context.Request.Headers["password"];
			var user = await User.TryLogIn(username, password);
			if (user == null)
				context.Response.Headers["user_exists"] = "0";
			else
			{
				context.Session.SetInt32("user_id", (int)user.Values["id"]);
				context.Response.Headers["user_exists"] = "1";
			}			
			// if (user == null) //TODO finish
			// 	context.Response.Redirect("login");
			// else
			// 	context.Response.Redirect("account-main");
		}

		private static async Task Register(HttpContext context)
		{
			var username = context.Request.Headers["username"];
			var password = context.Request.Headers["password"];
			var user = await User.TryRegister(username, password);
			if (user == null)
				context.Response.Headers["user_exists"] = "1";
			else
			{
				context.Session.SetInt32("user_id", (int)user.Values["id"]);
				context.Response.Headers["user_exists"] = "0";
			}
			// if (user == null) //TODO finish
			// 	context.Response.Redirect("register");
			// else
			// 	context.Response.Redirect("account-main");
		}
		
		public static async Task<Entity> GetUserInfoOrRedirect(HttpContext context)
		{
			var id = context.Session.GetInt32("user_id");
			// if (id == null)
			// 	context.Response.Redirect("login");
			if (id != null)
			{
				return await User.GetById((int) id);
			}
			return null;
		}
	}
}
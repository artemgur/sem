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
			if (user == null) //TODO finish
				//context.Response.Redirect("login");
				context.Response.Headers.Add("auth_result", "failure");
			else
			{
				//context.Response.Redirect("account-main");
				context.Response.Headers.Add("auth_result", "success");
				context.Session.SetInt32("user_id", (int) user.Values["id"]);
			}		
		}

		private static async Task Register(HttpContext context)
		{
			var username = context.Request.Headers["username"];
			var password = context.Request.Headers["password"];
			var user = await User.TryRegister(username, password);
			if (user == null) //TODO finish
				//context.Response.Redirect("register");
				context.Response.Headers.Add("auth_result", "failure");
			else
			{
				//context.Response.Redirect("account-main");
				context.Response.Headers.Add("auth_result", "success");
				context.Session.SetInt32("user_id", (int) user.Values["id"]);
			}		
		}
	}
}
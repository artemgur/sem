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
					Register(context);
				else
					LogIn(context);
			});
		}

		private static async void LogIn(HttpContext context)
		{
			var username = context.Request.Headers["username"];
			var password = context.Request.Headers["password"];
			var user = await User.TryLogIn(username, password);
			if (user == null) //TODO finish
				context.Response.Redirect("login");
			else
				context.Response.Redirect("account-main");
		}

		private static async void Register(HttpContext context)
		{
			var username = context.Request.Headers["username"];
			var password = context.Request.Headers["password"];
			var user = await User.TryRegister(username, password);
			if (user == null) //TODO finish
				context.Response.Redirect("register");
			else
				context.Response.Redirect("account-main");
		}
	}
}
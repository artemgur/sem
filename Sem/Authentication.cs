using System;
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
				//context.Response.Redirect("login");
				context.Response.Headers.Add("auth_result", "failure");
			else
			{
				//context.Response.Redirect("account-main");
				context.Response.Headers.Add("auth_result", "success");
				// if (context.Response.Headers["remember"] == "true")
				// 	context.Session.SetInt32("user_id", (int) user["id"]);
				// else
				context.Session.SetInt32("user_id", (int) user["id"]);
				if (context.Request.Headers["remember"].ToString() == "true")
					await Remember(context, (int) user["id"]);
			}		
		}

		private static async Task Register(HttpContext context)
		{
			var username = context.Request.Headers["username"];
			var password = context.Request.Headers["password"];
			var user = await User.TryRegister(username, password);
			if (user == null)
				//context.Response.Redirect("register");
				context.Response.Headers.Add("auth_result", "failure");
			else
			{
				//context.Response.Redirect("account-main");
				context.Response.Headers.Add("auth_result", "success");
				context.Session.SetInt32("user_id", (int) user["id"]);
				if (context.Request.Headers["remember"].ToString() == "true")
					await Remember(context, (int) user["id"]);
			}		
		}

		private static async Task Remember(HttpContext context, int id)
		{
			var guid = Guid.NewGuid();
			context.Response.Cookies.Append("guid", guid.ToString());
			await RememberedGuids.Add(guid, id);
		}

		public static void Exit(HttpContext context)
		{
			if (context.Session.GetInt32("user_id") != null)
				context.Session.Remove("user_id");
			var guid = context.Request.Cookies["guid"];//If no cookie - exception or default?
			context.Response.Cookies.Append("guid", "null");
			if (Guid.TryParse(guid, out var parsed))
				RememberedGuids.Remove(parsed);
		}
	}
}
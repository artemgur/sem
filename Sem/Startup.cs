using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Sem
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSession(/*options => options.IdleTimeout = TimeSpan.FromSeconds(20)*/);
			services.AddMemoryCache();
			services.AddRazorPages();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseStaticFiles();
			app.UseSession();
			// if (env.IsDevelopment())
			// {
			// 	app.UseDeveloperExceptionPage();
			// }
			// else
			// {
			app.UseExceptionHandler("/Error");
			// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
			app.UseHsts();
			//}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.Map("/authenticate", Authentication.Authenticate);
			app.Map("/favorite", FavoriteArticles.Manage);
			app.Map("/save_image", SaveImage.Save);
			app.Map("/create_debate", CreateDebate.Create);
			app.Map("/save_comment", SaveComment.Save);
			
			app.UseEndpoints(endpoints => { endpoints.MapRazorPages(); });
		}
	}
}
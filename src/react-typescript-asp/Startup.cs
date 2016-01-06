using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Formatters;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

namespace react_typescript_asp
{
	public class Startup
	{
		public Startup(IHostingEnvironment env)
		{
			// Set up configuration sources.
			var builder = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json")
				.AddEnvironmentVariables();

			if (env.IsDevelopment())
			{
				// For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
				builder.AddUserSecrets();
			}

			builder.AddEnvironmentVariables();
			Configuration = builder.Build();
		}

		public IConfigurationRoot Configuration { get; set; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// Add MVC services to the services container.
			services.AddMvc();

			services.Configure<MvcOptions>(options =>
			{
				var jsonOutputFormatter = new JsonOutputFormatter();
				jsonOutputFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
				options.OutputFormatters.Insert(0, jsonOutputFormatter);
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();
			app.UseDeveloperExceptionPage();

			if (env.IsDevelopment())
			{
				app.UseBrowserLink();
			}

			app.UseIISPlatformHandler();
			app.UseStaticFiles();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "all",
					template: "{*url}",
					defaults: new { controller = "Home", action = "Index" }
				);
			});
		}

		// Entry point for the application.
		public static void Main(string[] args) => WebApplication.Run<Startup>(args);
	}
}

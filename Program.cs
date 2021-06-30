using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Blazored.LocalStorage;
using helloworld.Services;

namespace helloworld
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            //Add httpClient
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://algorithon-server20210630072255.azurewebsites.net") });

            //Add LocalStorage
            builder.Services.AddBlazoredLocalStorage(config => config.JsonSerializerOptions.WriteIndented = true);

            //Configure logging
            builder.Logging.SetMinimumLevel(LogLevel.Debug);

            //Add Service
            builder.Services.AddScoped<AuthService>();
            builder.Services.AddScoped<ChallengeService>();

            var host = builder.Build();
            
            //Run service when app start
            var authService = host.Services.GetRequiredService<AuthService>();
            await authService.Initialize();

            await host.RunAsync();
        }
    }
}

using LiveDashboard.Client.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LiveDashboard.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddHttpClient("LiveDashboard.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            //builder.Services.AddScoped<LoadingIndicatorService>();
            //builder.Services.AddScoped<DisplayLoadingIndicatorHttpMessageHandler>();
            //builder.Services.AddScoped(s =>
            //{
            //    var accessTokenHandler = s.GetRequiredService<DisplayLoadingIndicatorHttpMessageHandler>();
            //    accessTokenHandler.InnerHandler = new HttpClientHandler();
            //    var uriHelper = s.GetRequiredService<NavigationManager>();
            //    return new HttpClient(accessTokenHandler)
            //    {
            //        BaseAddress = new Uri(uriHelper.BaseUri)
            //    };
            //});

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("LiveDashboard.ServerAPI"));

            builder.Services.AddApiAuthorization();

            await builder.Build().RunAsync();
        }
    }
}

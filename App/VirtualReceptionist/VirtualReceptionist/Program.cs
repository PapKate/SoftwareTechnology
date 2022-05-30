using Atom;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace VirtualReceptionist
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            
            // Add the routes used 
            builder.Services.AddSingleton<BlazorPagesPaths>();

            Framework.Construct<HostedFrameworkConstruction>();

            Framework.Construction.UseHostedServices(builder.Services)
                .AddConfiguration(builder.Configuration);

            var webAssemblyHost = builder.Build();

            Framework.Construction.Build(webAssemblyHost.Services);

            // Build the client application
            await webAssemblyHost.RunAsync();
        }
    }
}

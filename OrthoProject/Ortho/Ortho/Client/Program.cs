using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Ortho.Client.Data.Services.DemandInputs;
using System;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.JSInterop;
using Ortho.Client.Data.Services.ScenarioDefinition;
using System.Net.Http;
using Ortho.Client.Data.Services.ScenarioManager;
using Blazored.SessionStorage;

namespace Ortho.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddDevExpressBlazor();
            builder.Services.AddBlazoredSessionStorage();
            builder.Services.AddSingleton<StateContainer>();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<IPanelServices, PanelServices>();
            builder.Services.AddScoped<ILISFileServices, LISFileServices>();
            builder.Services.AddScoped<IAssayMappingServices, AssayMappingServices>();
            builder.Services.AddScoped<IScenarioServices, ScenarioServices>();
            builder.Services.AddScoped<IManagerServices, ManagerServices>();

            builder.Services.AddLocalization();
            var host = builder.Build();

            CultureInfo culture;
            var js = host.Services.GetRequiredService<IJSRuntime>();
            var result = await js.InvokeAsync<string>("blazorCulture.get");

            if (result != null)
                culture = new CultureInfo(result);
            else
            {
                culture = new CultureInfo("en-US");
                await js.InvokeVoidAsync("blazorCulture.set", "en-US");
            }

            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            await host.RunAsync();
        }
    }
}

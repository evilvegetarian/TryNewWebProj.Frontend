using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TryNewWebProj.Frontend;
using TryNewWebProj.Frontend.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient<LanguageService>();
builder.Services.AddTransient<WordService>();
builder.Services.AddTransient<TranslateService>();
builder.Services.AddTransient<SettingsWordService>();
builder.Services.AddBlazoredSessionStorage();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7071/api/") });






//builder.Services.AddHttpClient("companiesAPI", cl =>
//{
//    cl.BaseAddress = new Uri("https://localhost:7071/api/");
//})
//.AddHttpMessageHandler(sp =>
//{
//    var handler = sp.GetService<AuthorizationMessageHandler>()
//    .ConfigureHandler(
//         authorizedUrls: new[] { "https://localhost:7203" },
//         scopes: new[] { "openid profile WordWebAPI" }

//     );
//    return handler;
//});
//builder.Services.AddScoped(
//   sp => sp.GetService<IHttpClientFactory>().CreateClient("companiesAPI"));
builder.Services.AddOidcAuthentication(options =>
{
    //Configure your authentication provider options here.
    //For more information, see https://aka.ms/blazor-standalone-auth
    builder.Configuration.Bind("Local", options.ProviderOptions);

    options.ProviderOptions.Authority = "https://localhost:7203";
    options.ProviderOptions.ClientId = "word-web-app";

    options.ProviderOptions.DefaultScopes.Add("profile");
    options.ProviderOptions.DefaultScopes.Add("openid");
    options.ProviderOptions.DefaultScopes.Add("WordWebAPI");
    options.ProviderOptions.RedirectUri = "https://localhost:7000/signin-oidc";
    options.ProviderOptions.PostLogoutRedirectUri = "https://localhost:7000/signout-callback-oidc";
    options.ProviderOptions.ResponseType = "code";
    
});



await builder.Build().RunAsync();

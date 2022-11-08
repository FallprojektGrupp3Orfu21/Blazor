global using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using Economiq.Client;
using Economiq.Client.Service;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;




var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddMudServices();


builder.Services.AddTransient<RecipientService>();
builder.Services.AddSingleton<AppState>();
builder.Services.AddTransient<ExpenseService>();
builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<BudgetService>();
builder.Services.AddTransient<AuthService>();
builder.Services.AddTransient<ExpenseCategoryService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();
await builder.Build().RunAsync();

﻿using System.Text.Json;
using Blazored.LocalStorage;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Refit;
using TodoApp.Wasm;
using TodoApp.Wasm.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var refitSettings = new RefitSettings();
var serializerOptions = new JsonSerializerOptions()
{
    PropertyNameCaseInsensitive = true,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
};

serializerOptions.Converters.Add(new ObjectToInferredTypesConverter());
var customSerializer = new SystemTextJsonContentSerializer(serializerOptions);
refitSettings.ContentSerializer = customSerializer;

builder.Services.AddRefitClient<ITaskApiServices>(refitSettings)
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(builder.Configuration.GetValue<string>("Api")!));
builder.Services.AddRefitClient<IUserApiService>(refitSettings)
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(builder.Configuration.GetValue<string>("Api")!));
builder.Services.AddRefitClient<IIdentityApiService>(refitSettings)
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(builder.Configuration.GetValue<string>("Api")!));

builder.Services.AddBlazoredToast();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();
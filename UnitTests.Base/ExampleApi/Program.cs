using ExampleApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
var appName = typeof(Program).Assembly.GetName().Name;

builder.Services.AddControllers();
builder.Services.AddOpenApiDocument(x =>
{
    x.Title = appName;
    x.Version = "1.0.0";
});

builder.Services.AddScoped<IExampleService, StubExampleService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseOpenApi();
    app.UseSwaggerUi();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
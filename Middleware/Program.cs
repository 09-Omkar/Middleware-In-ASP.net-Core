using Microsoft.AspNetCore.Http;
using Middleware.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();
var app = builder.Build();

//Check username passed through URL and then run middleware
app.UseWhen(
    context => context.Request.Query.ContainsKey("username"),
    app =>
    {
        app.Use(async (HttpContext context, RequestDelegate next) =>
        {
            await context.Response.WriteAsync("Hello " + context.Request.Query["username"] + " \n");
            await next(context);
        });

    }
    ); ;



app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("middle ware 1 \n");
    await next(context);
});
//app.Use(async (HttpContext context, RequestDelegate next) =>
//{
//    await context.Response.WriteAsync("middle ware 2 \n");
//    await next(context);
//});

//--------------------
//used custom middleware class 
//app.UseMiddleware<MyCustomMiddleware>();

//-----
//used default class from .net
app.UseMiddleware();

app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("middle ware 3");

});

app.Run();
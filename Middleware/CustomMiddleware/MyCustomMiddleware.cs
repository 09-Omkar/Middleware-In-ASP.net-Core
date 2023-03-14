namespace Middleware.CustomMiddleware
// Creating middleware class  manually

{
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task  InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync( "hello from custom middleware class \n");
            await next(context);
        }
    }
}

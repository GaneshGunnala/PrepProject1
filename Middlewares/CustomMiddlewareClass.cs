namespace PrepProject.Middlewares
{
    public class CustomMiddlewareClass
    {
        private readonly RequestDelegate _next;
        public CustomMiddlewareClass(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Console.WriteLine("in the custom middleware: " + context.Request.Path);
            await _next(context);
            Console.WriteLine("Finished Middleware....");
        }

    }
}

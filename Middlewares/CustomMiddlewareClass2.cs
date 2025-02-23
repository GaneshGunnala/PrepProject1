namespace PrepProject.Middlewares
{
    public class CustomMiddlewareClass2
    {
        private readonly RequestDelegate _next;
        public CustomMiddlewareClass2(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context) {
            Console.WriteLine("Custom Middlware 2: "+context.Request.Path);
            await _next(context);
        }
    }
}

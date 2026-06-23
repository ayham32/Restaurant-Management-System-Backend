namespace RestaurantApi
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                   await _next(context);
            }
            catch 
            {
                await HandleExceptionAsync(context);
            }
        }

        private Task HandleExceptionAsync(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500;

            var result = new
            {
                message = "Something went wrong. Please try again."
            };

            return context.Response.WriteAsJsonAsync(result);
        }
    }
}

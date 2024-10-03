public class SecondMiddleware : IMiddleware
{
  public async Task InvokeAsync(HttpContext context, RequestDelegate next)
  {
    // Thực hiện logic trước khi chuyển sang middleware tiếp theo
    Console.WriteLine("Hello from SecondMiddleware before next middleware!\n");

    // Gọi middleware tiếp theo trong pipeline
    await next(context);

    // Thực hiện logic sau middleware tiếp theo
    Console.WriteLine("Hello from SecondMiddleware after next middleware!\n");
  }
}

public static class SecondMiddlewareExtensions
{
  public static IApplicationBuilder UseSecondMiddleware(this IApplicationBuilder builder)
  {
    return builder.UseMiddleware<SecondMiddleware>();
  }
}

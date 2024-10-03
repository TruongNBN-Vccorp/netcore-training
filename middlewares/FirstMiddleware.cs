public class FirstMiddleware
{
  private readonly RequestDelegate _next;

  public FirstMiddleware(RequestDelegate next)
  {
    _next = next;
  }

  public async Task InvokeAsync(HttpContext context)
  {
    // Thực hiện logic trước khi tiếp tục chuỗi middleware
    Console.WriteLine("Before next first-middleware");

    // Gọi middleware tiếp theo trong pipeline
    await _next(context);

    // Thực hiện logic sau khi middleware tiếp theo xử lý xong
    Console.WriteLine("After next first-middleware");
  }
}

public static class FirstMiddlewareExtensions
{
  public static IApplicationBuilder UseFirstMiddleware(this IApplicationBuilder builder)
  {
    return builder.UseMiddleware<FirstMiddleware>();
  }
}

var builder = WebApplication.CreateBuilder(args);

// Đăng ký dịch vụ vào DI container
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<SecondMiddleware>();

var app = builder.Build();

// Cấu hình pipeline xử lý yêu cầu
if (app.Environment.IsDevelopment())
{
  app.UseDeveloperExceptionPage();
}
else
{
  app.UseExceptionHandler("/Home/Error");
  app.UseHsts();
}
app.UseStaticFiles();

app.UseFirstMiddleware();
app.UseSecondMiddleware();

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

// Định tuyến endpoint
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseStatusCodePages();

app.Run();

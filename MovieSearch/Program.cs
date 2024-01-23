using MovieSearch.Interface;
using MovieSearch.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.WithOrigins("https://localhost:7009", "https://localhost:44441")
               .AllowAnyMethod().AllowAnyHeader().AllowCredentials();
        });

});
builder.Services.AddHttpClient();
builder.Services.AddControllers();
builder.Services.AddSingleton<IMovieService, MovieService>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("AllowAll");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");
//app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();

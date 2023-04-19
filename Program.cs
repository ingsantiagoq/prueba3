
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container...
builder.Services.AddControllersWithViews();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("https://localhost:7092")
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   ;
        });
});

 

var app = builder.Build();



//app.Use(async (context, next) =>
//{
//    // Agregar cabecera Content-Security-Policy
//    context.Response.Headers.Add("Content-Security-Policy",
//        "default-src 'self' https://localhost:7092");

//    // Pasar la solicitud al siguiente middleware
//    await next.Invoke();
//});



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");




app.Run();

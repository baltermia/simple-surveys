using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Scalar.AspNetCore;
using SimpleSurveys.Data.Configuration;
using SimpleSurveys.Server.Repositories;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            
// DB Context
builder.Services.AddDbContext<SimpleSurveysContext>(options => options.UseNpgsql(connectionString));

// Repository Wrapper
// TODO remove repository since using EF directly
builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

builder.Services.AddOpenApi();
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
builder.Services.AddRazorPages();
            
//builder.Services.AddCors(options =>  
//{  
//    options.AddPolicy("AllowBlazorOrigin", policy =>  
//    {  
//        // Replace with your Blazor app's origin (e.g., http://localhost:5000)  
//        policy.WithOrigins("http://localhost:5002")  
//            .AllowAnyHeader() // Allows headers like Content-Type  
//            .AllowAnyMethod(); // Allows HTTP methods (GET, POST, etc.)  
//    });  
//});  

WebApplication app = builder.Build();

// Migrate and create database
using (IServiceScope serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    // Gets the context
    SimpleSurveysContext context = serviceScope.ServiceProvider.GetRequiredService<SimpleSurveysContext>();

    // Execute Migrations
    context.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseWebAssemblyDebugging();
    app.MapOpenApi();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
//app.UseCors("AllowBlazorOrigin");  
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.MapScalarApiReference(o =>
    o.WithTheme(ScalarTheme.Moon)
);

app.Run();

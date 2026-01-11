using Microsoft.EntityFrameworkCore;
using URL_Shortner_API.Data;
using URL_Shortner_API.Middleware;
using URL_Shortner_API.Services;
using URL_Shortner_API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// -------------------- SERVICES --------------------

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UrlShortenerDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// ?? ADD CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddScoped<IUrlService, UrlService>();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// -------------------- MIDDLEWARE --------------------

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ?? USE CORS (IMPORTANT: before MapControllers)
app.UseCors("AllowAll");

app.UseHttpsRedirection();

// ?? REDIRECT ENDPOINT
app.MapGet("/{shortCode}", async (string shortCode, IUrlService service) =>
{
    var originalUrl = await service.GetOriginalUrlAsync(shortCode);
    return originalUrl == null
        ? Results.NotFound()
        : Results.Redirect(originalUrl);
});

app.MapControllers();
app.Run();

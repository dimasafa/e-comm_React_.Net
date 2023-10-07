using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add dbContext
builder.Services.AddDbContext<StoreContext>(opt =>
{
    // Erstellen die Connection
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Add Cors, um aus Frontend requests zu erhalten(da front und back unterschidliche Domain besitzen)
builder.Services.AddCors();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Add Cors zum app
app.UseCors(opt => 
{
    // erlauben any Headers, any Methode(get, post usw.), und die domain aus Frontend
    opt.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
});

app.UseAuthorization();

app.MapControllers();

// Verbinden zum Scope
var scope = app.Services.CreateScope();
// Erhalten new StoreContext, um zum Db zu verbinden
var context = scope.ServiceProvider.GetRequiredService<StoreContext>();
// Erstellen new logger
var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
try
{
    // automatische Migration aus DbIntializer. wenn es nötig 
    context.Database.Migrate();
    DbIntializer.Initialize(context);
}
catch (Exception ex)
{
    // Documentieren die Exception in logger
    logger.LogError(ex, "Das Problem während Migration");
    
}

app.Run();

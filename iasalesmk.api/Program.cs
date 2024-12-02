using iasalesmk.api.Extensions;
using iasalesmk.infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.ConfigureCors();
builder.Services.AddAplicacionServices(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// ... existing code ...
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// ... existing code ...

builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseInMemoryDatabase("TempDatabase"));

// public void ConfigureServices(IServiceCollection services)
// {
//     services.AddDbContext<ApplicationDbContext>(options =>
//         options.UseInMemoryDatabase("TempDatabase"));
//     // ... otros servicios
// }


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();


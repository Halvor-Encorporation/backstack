using backstack.Data.Context;
using backstack.Services;
using Microsoft.EntityFrameworkCore; // Add this using directive

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<MoneyContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddScoped<ICoinService, CoinService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

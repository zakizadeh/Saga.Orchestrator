using Inventory.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();



builder.Services.AddHttpClient("Inventory", httpClient =>
{
    httpClient.BaseAddress = new Uri("http://localhost");
});

builder.Services.AddScoped<InventoryController>();

var servicesProvider = builder.Services.BuildServiceProvider(validateScopes: true);
using (var scope = servicesProvider.CreateScope())
{
    var client = scope.ServiceProvider.GetRequiredService<InventoryController>();
}





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

app.UseAuthorization();

app.MapControllers();

app.Run();

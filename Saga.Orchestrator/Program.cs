var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient("Order", c => c.BaseAddress = new Uri("http://localhost:5233"));
builder.Services.AddHttpClient("Inventory", c => c.BaseAddress = new Uri("http://localhost:5209"));
builder.Services.AddHttpClient("Notifier", c => c.BaseAddress = new Uri("http://localhost:5080"));
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

app.UseAuthorization();

app.MapControllers();

app.Run();

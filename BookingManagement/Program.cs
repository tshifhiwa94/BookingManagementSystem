using BookingManagement.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.BookingManagentDomain(builder.Configuration);

// 📦 Swagger/OpenAPI setup
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 🚀 Build and configure the app
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

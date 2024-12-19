var builder = WebApplication.CreateBuilder(args);

// Add services to the container before building the application

var app = builder.Build();

// Configure the HTTP request pipeline

app.Run();

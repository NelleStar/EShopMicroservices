var builder = WebApplication.CreateBuilder(args);

// Add services to the container before building the application
// Dependencay Injection Configuration
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

var app = builder.Build();

// Configure the HTTP request pipeline
app.MapCarter();

app.Run();

using DpWorld.Visitor.Application.Interfaces;
using DpWorld.Visitor.Application.Services;
using DpWorld.Visitor.Infrastructure.Persistence;
using VisitorReg.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer(); // Add this line to register API explorer
builder.Services.AddSwaggerGen(); // Add this line to register Swagger generator

builder.Services.AddSingleton<InMemoryDatabase>();
builder.Services.AddScoped<IVisitorRepository, VisitorRepository>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<IEntranceRepository, EntranceRepository>();

// Application
builder.Services.AddScoped<IVisitorService, VisitorService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseSwagger(); // This will now work because Swagger services are registered
app.UseSwaggerUI(); // This will now work because Swagger UI services are registered

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();

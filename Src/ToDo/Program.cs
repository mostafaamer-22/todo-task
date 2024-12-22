using Serilog;
using ToDo.Api.Configurations;
using ToDo.Api.Middleware;
using ToDo.Application;
using ToDo.Infrasturcture;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLocalizationConfig();
builder.Host.ConfigureSerilog();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddProblemDetails();
builder.Services.AddApplicationStrapping();
builder.Services.AddInfrastructureStrapping(builder.Configuration);
builder.Services.AddExceptionHandler<GlobalExceptionHandlerMiddleware>();


builder.Services.AddSwaggerGen(c =>
{
    c.UseOneOfForPolymorphism();
    c.DescribeAllParametersInCamelCase();
});

var app = builder.Build();

app.UseCors(corsBuilder =>
{
    corsBuilder
       .AllowAnyOrigin()
       .AllowAnyMethod()
       .AllowAnyHeader();
});

app.UseSwagger();

app.UseSwaggerUI();

app.UseRequestLocalization();

app.UseHsts();

app.UseHttpsRedirection();

app.UseSerilogRequestLogging();

app.UseStaticFiles();

app.MapControllers();

app.Run();

using Serilog;
using MovieRentMicroservice.Application;
using MovieRentMicroservice.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
	.AddApplication()
	.AddInfrastructure();

string? whitelistUrl = builder.Configuration.GetSection("CorsConfig:Whitelist").Get<string>();

//builder.Host.UseSerilog((context, configuration) =>
//configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

if (whitelistUrl == null)
{
	throw new Exception("The CorsConfiguration is not valid in appsettings !");
}

app.UseCors(builder => builder
	.WithOrigins(whitelistUrl)
	.AllowAnyMethod()
	.AllowAnyHeader()
	.AllowCredentials());

//app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
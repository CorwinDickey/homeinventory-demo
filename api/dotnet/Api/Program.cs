using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Repository;

var builder = WebApplication.CreateBuilder(args);

// Add environment variables to the container.
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

// Add DbContext to the container.
builder.Services.AddDbContext<IRepoContext, RepoContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("Database");
    if (connectionString == null)
    {
        throw new ArgumentNullException(nameof(connectionString));
    }

    options.UseSqlServer(connectionString);
});

// Add Application Insights to the container.
string? appInsightsConnectionString = builder.Configuration.GetConnectionString("ApplicationInsights");
if (!string.IsNullOrWhiteSpace(appInsightsConnectionString))
{
    builder.Services.AddApplicationInsightsTelemetry(options =>
    {
        options.ConnectionString = appInsightsConnectionString;
        options.AddAutoCollectedMetricExtractor = false;
        options.EnableAppServicesHeartbeatTelemetryModule = false;
        options.EnableAuthenticationTrackingJavaScript = false;
        options.EnableAdaptiveSampling = false;
        options.EnableDependencyTrackingTelemetryModule = false;
        options.EnableQuickPulseMetricStream = false;
        options.ApplicationVersion = Assembly.GetExecutingAssembly()?.GetName()?.Version?.ToString();
    });
}

// Add services to the container.

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

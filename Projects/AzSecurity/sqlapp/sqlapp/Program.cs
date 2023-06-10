using Microsoft.ApplicationInsights.DependencyCollector;
using Microsoft.FeatureManagement;
using sqlapp.Services;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

//var connectionString = "Endpoint=https://azureappconfig10.azconfig.io;Id=eOCf-l8-s0:zcN8=";
//builder.Host.ConfigureAppConfiguration(builder =>
//{
//    builder.AddAzureAppConfiguration(options =>
//    {
//        options.Connect(connectionString)
//            .UseFeatureFlags();
//    });
//});

string redisConnectionString = "appcache1000.redis.cache.windows.net:6380,password=4o5FaUASBDttACpArQSE7Dp29dAn655RxAzCaAES60c=,ssl=True,abortConnect=False";
var multiplexer = ConnectionMultiplexer.Connect(redisConnectionString);
builder.Services.AddSingleton<IConnectionMultiplexer>(multiplexer);
builder.Services.AddTransient<IProductService, ProductService>();

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddFeatureManagement();
builder.Services.AddApplicationInsightsTelemetry();

builder.Services.ConfigureTelemetryModule<DependencyTrackingTelemetryModule>((module, o) => { module.EnableSqlCommandTextInstrumentation = true; });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SaluteStocksAPI.DataBase;
using SaluteStocksAPI.Service;
using SaluteStocksAPI.Service.Background;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((context, configuration) =>
    {
        configuration
            .WriteTo.Console()
            .WriteTo.File($@"Logs/Log_{DateTime.Now:yyyy-MM-dd_hh-mm-ss}.log");
    });

    // Add services to the container.

    builder.Services.AddControllers();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "SaluteStocksAPI", Version = "v1" });
    });

    //DB Context
    builder.Services.AddDbContext<StocksContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQL")));

    //DB repository
    builder.Services.AddScoped<IDataBaseRepository, DataBaseRepository>();
    //Screener
    builder.Services.AddScoped<ScreenerService>();
    //Loader background service
    builder.Services.AddHostedService(provider => new Loader(
        new LoaderSettings
        {
            CheckUpdateTime = TimeSpan.FromSeconds(20),
            LoadMissingDataDelay = TimeSpan.FromMinutes(5)
        }, provider.GetService<IServiceScopeFactory>()));

    var app = builder.Build();
    

    // Configure the HTTP request pipeline.
    if (builder.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SaluteStocksAPI v1"));
    }

    app.UseHttpsRedirection();

    //app.UseAuthorization();

    app.MapControllers();
    app.Run();
    Log.Information("Stopped cleanly");
    return 0;
}
catch (Exception ex)
{
    Log.Fatal(ex, "An unhandled exception occured during bootstrapping");
    return 1;
}
finally
{
    Log.CloseAndFlush();
}
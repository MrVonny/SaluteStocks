using Microsoft.EntityFrameworkCore;
using SaluteStocksAPI.DataBase;
using SaluteStocksAPI.Service;
using SaluteStocksAPI.Service.Background;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new() { Title = "SaluteStocksAPI", Version = "v1" }); });

//DB Context
builder.Services.AddDbContext<StocksContext>(
    options => options.UseMySql(builder.Configuration.GetConnectionString("MySql"),
    MySqlServerVersion.LatestSupportedServerVersion));

//DB repository
builder.Services.AddScoped<IDataBaseRepository, DataBaseRepository>();
//Screener
builder.Services.AddScoped<ScreenerService>();
//Loader background service
builder.Services.AddHostedService(provider => new Loader(
        new LoaderSettings
        {
            CheckUpdateTime = TimeSpan.FromSeconds(2)
        },
        provider.GetService<IServiceScopeFactory>()
    )
);


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
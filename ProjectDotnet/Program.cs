//using Microsoft.AspNetCore.Http;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.FileSystemGlobbing;
//using Subscriber.WebApi.Config;
//using Weight_Watchers.data;

//var builder = WebApplication.CreateBuilder(args);
//ConfigurationManager configuration = builder.Configuration;

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.Configurations();
//builder.Services.AddDbContext<SubscriberContext>(option =>
//{
//    option.UseSqlServer(configuration.GetConnectionString("DietConnectionString"));
//}
//       );
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseAuthorization();

//app.MapControllers();
//app.UseMiddleware(typeof(ErrorEventHandler));
//app.Run();

using Microsoft.EntityFrameworkCore;
using Serilog;

using Subscriber.WebApi.Config;
using Weight_Watchers.data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddControllers();

builder.Services.Configurations();
builder.Host.UseSerilog((context, configuration) =>
{

    configuration.ReadFrom.Configuration(context.Configuration);

});

builder.Services.AddDbContext<SubscriberContext>(option =>
{

    option.UseSqlServer(configuration.GetConnectionString("WeightWatchersConnectionString"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(opt => opt.AddPolicy("MyPolicy", policy =>
{
    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
})
);


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSerilogRequestLogging();
app.UseAuthorization();
app.UseCors("MyPolicy");
app.MapControllers();

app.UseMiddleware(typeof(ErrorHandlingMiddleware));

app.Run();

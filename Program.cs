using DentalAppAPIDemo.Entites;
using DentalAppAPIDemo.Repositories.Abstract;
using DentalAppAPIDemo.Repositories.Concrete;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IPatientRepository, PatientRepository>();


builder.Services.Configure<DataBaseSettings>(
                builder.Configuration.GetSection(nameof(DataBaseSettings)));

builder.Services.AddSingleton<DataBaseSettings>(sp =>
    sp.GetRequiredService<IOptions<DataBaseSettings>>().Value);

// //builder.Services.Configure<DataBaseSettings>(
// //    builder.Configuration.GetSection(nameof(DataBaseSettings)));


builder.Services.AddSingleton<IMongoClient>(s =>
        new MongoClient(builder.Configuration.GetValue<string>("DataBaseSettings:ConnectionString")));



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

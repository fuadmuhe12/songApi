
using SongApi.Data;
using SongApi.Interface;
using SongApi.Repository;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SongLightDataBase");
builder.Services.AddSqlite<SongContext>(connectionString);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ISongRepository, SongRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.MapControllers();
app.MigrateDb();
app.Run();
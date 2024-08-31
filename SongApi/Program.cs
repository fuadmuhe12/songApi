
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
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:6526", "https://songapi-j4rk.onrender.com", "https://song-player-f.vercel.app")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});
var app = builder.Build();
app.UseCors("AllowOrigin");


app.UseSwagger();
app.UseSwaggerUI();


app.MapControllers();
app.MigrateDb();
app.Run();
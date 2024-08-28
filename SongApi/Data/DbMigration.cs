using Microsoft.EntityFrameworkCore;

namespace SongApi.Data;

public static class DbMigration
{
    public static void MigrateDb(this WebApplication app )
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<SongContext>();
        dbContext.Database.Migrate();
    }
}
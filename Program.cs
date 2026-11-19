using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using PortfolioSite.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<PortfolioContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("PortfolioDb")));

var app = builder.Build();

// Initialize database: apply any pending migrations so seeded content (experience, projects, documents) stays current.
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<PortfolioContext>();
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    var creator = context.Database.GetService<IRelationalDatabaseCreator>();

    // A database created earlier with EnsureCreated() has tables but no migration history,
    // so Migrate() would fail on "table already exists". It only holds seed data, so rebuild it.
    if (creator.Exists() && creator.HasTables() && !context.Database.GetAppliedMigrations().Any())
    {
        logger.LogWarning("Database has no migration history; recreating it from migrations.");
        context.Database.EnsureDeleted();
    }

    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.Run();
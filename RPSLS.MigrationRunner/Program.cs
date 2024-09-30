using RPSLS.MigrationRunner;
using Microsoft.EntityFrameworkCore;

using var context = new ApiDbContextFactory().CreateDbContext(args);

context.Database.Migrate();
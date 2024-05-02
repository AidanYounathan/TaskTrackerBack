using TaskTrackerBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskTrackerBackend.Services.Context;

public class DataContext : DbContext
{
    public DbSet<UserModel> UserInfo { get; set; }
    public DbSet<PostModel> PostInfo { get; set; }

    public DbSet<CommentsModel> CommentInfo { get; set; }
    public DbSet<AppModels> AppInfo { get; set; }
    public DbSet<BoardModel> BoardInfo { get; set; }

    public DataContext(DbContextOptions options) : base(options) { }

    // this function will build out our table in the database
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}

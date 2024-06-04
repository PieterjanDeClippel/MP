using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MP.Data.Entities;
using System.Data;

namespace MP.Data;

public class MintPlayerContext : IdentityDbContext<User, Role, Guid>
{
    private readonly IConfiguration configuration;
    public MintPlayerContext(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TestDatabase;Trusted_Connection=True;MultipleActiveResultSets=true;ConnectRetryCount=0");
        var connectionstring = configuration.GetConnectionString("Application");
        optionsBuilder.UseSqlServer(connectionstring);
        //optionsBuilder.UseInMemoryDatabase("Application");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Subjects
        modelBuilder.Entity<Subject>().ToTable("Subjects");
        modelBuilder.Entity<Subject>().HasQueryFilter(s => s.UserDelete == null);
        modelBuilder.Entity<Subject>().HasDiscriminator<string>("SubjectType")
            .HasValue<Song>("song");

        // Tag category
        modelBuilder.Entity<TagCategory>().Property(tc => tc.Color).HasConversion(color => color.ToArgb(), argb => System.Drawing.Color.FromArgb(argb));

        //modelBuilder.Entity<Subject>()
        //    .HasMany(s => s.Tags)
        //    .WithMany(t => new List<Subject>())
        //    .UsingEntity<SubjectTag>();

        // Many-to-many Subject-Tag
        //modelBuilder.Entity<SubjectTag>().HasKey(st => new { st.SubjectId, st.TagId });
        //modelBuilder.Entity<SubjectTag>().HasOne(st => st.Subject).WithMany(s => s.Tags).HasForeignKey(st => st.SubjectId).OnDelete(DeleteBehavior.Restrict);
        //modelBuilder.Entity<SubjectTag>().HasOne(st => st.Tag).WithMany(t => t.Subjects).HasForeignKey(st => st.TagId).OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Subject>()
            .HasMany(s => s.Tags)
            .WithMany(t => t.Subjects)
            .UsingEntity<SubjectTag>();
    }

    public DbSet<Song> Songs { get; set; }
    public DbSet<Medium> Media { get; set; }
    public DbSet<MediumType> MediumTypes { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<TagCategory> TagCategories { get; set; }
}

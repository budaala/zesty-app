using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using zesty_api.Data.Entities;

namespace zesty_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }

        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            ConfigureUser(builder.Entity<UserEntity>());
            ConfigureRecipe(builder.Entity<RecipeEntity>());
            ConfigureRating(builder.Entity<RatingEntity>());
            ConfigureComment(builder.Entity<CommentEntity>());
            ConfigureMealType(builder.Entity<MealTypeEntity>());
        }

        private void ConfigureUser(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Username).HasMaxLength(100).IsRequired();
            builder.Property(u => u.Password).IsRequired();
            builder.Property(u => u.Email).IsRequired();

            builder.HasIndex(u => u.Username).IsUnique();
            builder.HasIndex(u => u.Email).IsUnique();
        }

        private void ConfigureRecipe(EntityTypeBuilder<RecipeEntity> entity)
        {
            entity.ToTable("Recipes");
            entity.HasKey(r => r.Id);
            entity.Property(r => r.Title).HasMaxLength(100).IsRequired();
            entity.Property(r => r.Description).IsRequired();
            entity.Property(r => r.Ingredients).HasColumnType("TEXT").IsRequired();
            entity.Property(r => r.Instructions).HasColumnType("TEXT").IsRequired();
            entity.Property(r => r.ImageUrl).HasMaxLength(500).IsRequired();
            entity.Property(r => r.CreatedAt).IsRequired().HasDefaultValueSql("GETUTCDATE()");

            entity.HasOne(r => r.User)
                  .WithMany()
                  .HasForeignKey(fk => fk.UserId);

            entity.HasOne(r => r.MealType)
                  .WithMany()
                  .HasForeignKey(fk => fk.MealTypeId);

            entity.HasMany(r => r.Comments)
                  .WithOne()
                  .HasForeignKey(fk => fk.RecipeId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(r => r.Ratings)
                  .WithOne()
                  .HasForeignKey(fk => fk.RecipeId)
                  .OnDelete(DeleteBehavior.Cascade);

        }
        private void ConfigureRating(EntityTypeBuilder<RatingEntity> entity)
        {
            entity.ToTable("Ratings");
            entity.HasKey(r => r.Id);
            entity.Property(r => r.Value).IsRequired();
            entity.Property(r => r.CreatedAt).IsRequired().HasDefaultValueSql("GETUTCDATE()");
            entity.Property(r => r.UserId).IsRequired();
            entity.Property(r => r.RecipeId).IsRequired();
            entity.HasIndex(r => new { r.RecipeId, r.UserId }).IsUnique();


        }

        private void ConfigureComment(EntityTypeBuilder<CommentEntity> entity)
        {
            entity.ToTable("Comments");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Content).HasMaxLength(2000).IsRequired();
            entity.Property(c => c.UserId).IsRequired();
            entity.Property(c => c.RecipeId).IsRequired();
            entity.Property(c => c.CreatedAt).IsRequired().HasDefaultValueSql("GETUTCDATE()");
        }

        private void ConfigureMealType(EntityTypeBuilder<MealTypeEntity> entity)
        {
            entity.ToTable("MealTypes");
            entity.HasKey(m => m.Id);
            entity.Property(m => m.Name).HasMaxLength(100).IsRequired();
            entity.HasIndex(m => m.Name).IsUnique();
        }


        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RecipeEntity> Recipes { get; set; }
        public DbSet<RatingEntity> Ratings { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<MealTypeEntity> MealTypes { get; set; }
    }
}

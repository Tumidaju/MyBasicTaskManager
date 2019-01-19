namespace MyBasicTaskManager.Models.Infrastructure
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DatabaseModel : DbContext
    {
        public DatabaseModel()
            : base("name=DatabaseModel")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<CATEGORY> CATEGORY { get; set; }
        public virtual DbSet<RANK> RANK { get; set; }
        public virtual DbSet<STATUS> STATUS { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TASK> TASK { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.TASK)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.USER_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CATEGORY>()
                .HasMany(e => e.TASK)
                .WithRequired(e => e.CATEGORY)
                .HasForeignKey(e => e.CATEGORY_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RANK>()
                .HasMany(e => e.TASK)
                .WithRequired(e => e.RANK)
                .HasForeignKey(e => e.RANK_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<STATUS>()
                .HasMany(e => e.TASK)
                .WithRequired(e => e.STATUS)
                .HasForeignKey(e => e.STATUS_ID)
                .WillCascadeOnDelete(false);
        }
    }
}

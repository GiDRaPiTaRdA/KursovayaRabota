namespace ConsoleApplication3
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class HyinyaContext : DbContext
    {
        public HyinyaContext()
            : base("name=HyinyaContext")
        {
        }


        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<University> Unversities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                        .HasMany<Course>(s => s.Courses)
                        .WithMany(c => c.Students)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("StudentRefId");
                            cs.MapRightKey("CourseRefId");
                            cs.ToTable("StudentCourse");
                        });

            modelBuilder.Entity<University>()
            .HasMany<Student>(s => s.Students)
            .WithMany(c => c.Universities)
            .Map(cs =>
            {
                cs.MapLeftKey("UniverRefId");
                cs.MapRightKey("StudentRefId");
                cs.ToTable("UniverStudent");
            });

        }
    }


}
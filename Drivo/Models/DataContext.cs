namespace Drivo.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }

        public virtual DbSet<DrivingSchool_Instructors> DrivingSchool_Instructors { get; set; }
        public virtual DbSet<DrivingSchool> DrivingSchools { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DrivingSchool>()
                .HasMany(e => e.DrivingSchool_Instructors)
                .WithRequired(e => e.DrivingSchool)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Instructor>()
                .HasMany(e => e.DrivingSchool_Instructors)
                .WithRequired(e => e.Instructor)
                .WillCascadeOnDelete(false);
        }
    }
}

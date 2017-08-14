namespace Drivo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DrivingSchool_Instructors
    {
        [Key]
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        public string InstructorsDrivingSchoolId { get; set; }

        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        public DateTime CreateDate { get; set; }

        public DateTime EditDate { get; set; } = DateTime.UtcNow;

        [Required]
        [StringLength(128)]
        public string InstructorId { get; set; }

        [Required]
        [StringLength(128)]
        public string DrivingSchoolId { get; set; }

        [ForeignKey("DrivingSchoolId")]
        public virtual DrivingSchool DrivingSchool { get; set; }

        [ForeignKey("InstructorId")]
        public virtual Instructor Instructor { get; set; }
    }
}

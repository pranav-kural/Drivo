namespace Drivo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Instructor
    {
        public Instructor()
        {
            DrivingSchool_Instructors = new HashSet<DrivingSchool_Instructors>();
        }

        [Key]
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        public string InstructorId { get; set; }

        [Required]
        [StringLength(50)]
        public string Firstname { get; set; }

        [Required]
        [StringLength(50)]
        public string Lastname { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

        [Required]
        [StringLength(1)]
        public string Gender { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Description = "Do you have a valid Driving Instructors Licence?", Name = "Driving Instructors Licence")]
        public string Driving_instructor_licence { get; set; }

        [Column(TypeName = "date")]
        public DateTime Working_since { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(256)]
        public string Email { get; set; }
        
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(256)]
        public string UserName { get; set; }

        [Required]
        [StringLength(500)]
        public string About { get; set; }

        [Required]
        [StringLength(250)]
        public string Licences_held { get; set; }

        [Required]
        [StringLength(250)]
        public string Licences_training_for { get; set; }

        [Required]
        [StringLength(30)]
        public string Province { get; set; }

        [Required]
        public string Cities_of_operation { get; set; }

        [StringLength(500)]
        public string Vehicles_used { get; set; }
        
        public virtual ICollection<DrivingSchool_Instructors> DrivingSchool_Instructors { get; set; }
    }
}

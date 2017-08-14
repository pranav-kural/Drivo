namespace Drivo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DrivingSchool
    {
        public DrivingSchool()
        {
            DrivingSchool_Instructors = new HashSet<DrivingSchool_Instructors>();
        }

        [Key]
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        public string DrivingSchoolId { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Experience")]
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
        public string About { get; set; }

        [Required]
        public string Licences_training_for { get; set; }

        [Required]
        [StringLength(30)]
        public string Province { get; set; }

        [Required]
        public string Cities_of_operation { get; set; }

        [StringLength(1000)]
        public string Vehicles_used { get; set; }
        
        public virtual ICollection<DrivingSchool_Instructors> DrivingSchool_Instructors { get; set; }
    }
}

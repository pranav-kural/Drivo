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
        [Display(Name = "Driving School's Name")]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Working Since")]
        [DataType(DataType.Date)]
        public DateTime Working_since { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(256)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string PasswordHash { get; set; }

        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(256)]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "About your Driving School")]
        public string About { get; set; }

        [Required]
        [Display(Name = "Vehicle Licences you provide training for")]
        public string Licences_training_for { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Province of Operation")]
        public string Province { get; set; }

        [Required]
        [Display(Name = "Cities you provide service in")]
        public string Cities_of_operation { get; set; }

        [StringLength(1000)]
        [Display(Name = "Vehicles you use for training")]
        public string Vehicles_used { get; set; }
        
        public virtual ICollection<DrivingSchool_Instructors> DrivingSchool_Instructors { get; set; }
    }
}

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
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required]
        [StringLength(1)]
        [EnumDataType(typeof(GenderOptions))]
        public string Gender { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Description = "Do you have a valid Driving Instructors Licence?", Name = "Driving Instructors Licence")]
        public string Driving_instructor_licence { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [Display(Name = "Experience")]
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
        [StringLength(500)]
        [Display(Name = "About Yourself")]
        public string About { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Vehicle Licences owned by you")]
        public string Licences_held { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Vehicle Licences you train for")]
        public string Licences_training_for { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Province of Operation")]
        public string Province { get; set; }

        [Required]
        [Display(Name = "Cities of Operation")]
        public string Cities_of_operation { get; set; }

        [StringLength(500)]
        [Display(Name = "Vehicles Used")]
        public string Vehicles_used { get; set; }

        // Possible options for Gender property
        public enum GenderOptions
        {
            M, //Male
            F, //Female
            O  //Other
        }

        // Possible options for Province property
        public enum ProvinceOptions
        {
            ONTARIO,
            NEWFOUNDLAND_AND_LABRADO,
            SASKATCHEWAN,
            PRINCE_EDWARD_ISLAND,
            BRITISH_COLUMBIA,
            MANITOBA,
            NEW_BRUNSWICK,
            NOVA_SCOTIA,
            QUEBEC
        }

        public virtual ICollection<DrivingSchool_Instructors> DrivingSchool_Instructors { get; set; }
    }
}

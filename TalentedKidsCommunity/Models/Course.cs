using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalentedKidsCommunity.Models
{
    public enum CourseDay
    {
        Saturday, Sunday, Monday, Tuesday, Wedensday, Thursday, Friday,
    }
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name="Course Code")]
        public int CourseID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Course Fee")]
        [Column(TypeName = "money")] // to map double data type to SQL server money data type 
        public double CourseFee { get; set; }
        [Required]
        public CourseDay CourseDay { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}",
        //               ApplyFormatInEditMode = true)]
        //[Display(Name = "Start Date")]
        //public DateTime StartDate { get; set; }

        //[DataType(DataType.Time)]
        //[Display(Name = "Course Start Time")]
        //public DateTime CourseStarttime { get; set; }

        public int DepartmentID { get; set; }

        public Department Department { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; } // Enrollments (HashSet<Enrollment>): holds all enrollments related to the course
        public ICollection<Instructor> Instructors { get; set; }
    }
}

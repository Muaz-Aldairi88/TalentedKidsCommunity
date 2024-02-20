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
        public int CourseID { get; set; }
        public string? Title { get; set; }
        public double CourseFee { get; set; }
        public CourseDay CourseDay { get; set; }
        public ICollection<Enrollment>? Enrollments { get; set; } // Enrollments (HashSet<Enrollment>): holds all enrollments related to the course
    }
}

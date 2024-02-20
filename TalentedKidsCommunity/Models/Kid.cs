using System.ComponentModel.DataAnnotations;

namespace TalentedKidsCommunity.Models
{
    public class Kid
    {
        public int KidID { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public int Age { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }
        public ICollection<Enrollment>? Enrollments { get; set; } // Enrollments (HashSet<Enrollment>): Navigation property holds all enrollments related to the kid
    }
}

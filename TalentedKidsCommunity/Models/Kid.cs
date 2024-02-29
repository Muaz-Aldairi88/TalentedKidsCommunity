using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalentedKidsCommunity.Models
{
    public class Kid
    {
        public int KidID { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Last name cannot be longer than 25 characters.")]
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        public string LastName { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "First name cannot be longer than 25 characters.")]
        [Display(Name = "First Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]// name should start with uppercase letter and contains only letters
        public string FirstName { get; set; }
        [Range(5, 18, ErrorMessage = "Age must be between 5 and 18.")]// non-nullable types such as value types (DateTime, int, and double) are automatically treated as required fields.
        public int Age { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Enrollment Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }

        [Display(Name = "Full Name")]
        public string FullName //calculated property, is not created in the database
        {
            get { return FirstName + " " + LastName; }
        }
        public ICollection<Enrollment> Enrollments { get; set; } // Enrollments (HashSet<Enrollment>): Navigation property holds all enrollments related to the kid
    }
}

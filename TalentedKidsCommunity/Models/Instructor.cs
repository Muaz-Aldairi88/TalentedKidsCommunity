using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TalentedKidsCommunity.Models
{
    public class Instructor
    {
        public int InstructorID { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Last name cannot be longer than 25 characters.")]
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        public string LastName { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Last name cannot be longer than 25 characters.")]
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 4)]
        public string Talend {  get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return FirstName + " "+ LastName; }
        }

        // navigation properties
        public ICollection<Course> Courses { get; set; }
        public CenterAssignment CenterAssignment { get; set; }
    }
}


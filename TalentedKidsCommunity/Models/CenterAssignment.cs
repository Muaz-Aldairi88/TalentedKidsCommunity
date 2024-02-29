using System.ComponentModel.DataAnnotations;

namespace TalentedKidsCommunity.Models
{
    public class CenterAssignment
    {
        [Key]
        public int InstructorID { get; set; }
        [StringLength(25)]
        [Display(Name = "Center Location")]
        public string Location { get; set; }

        public Instructor Instructor { get; set; }
    }
}

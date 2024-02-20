namespace TalentedKidsCommunity.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; } // foreign key for the Course navigation property // primary key in Course class
        public int KidID { get; set; } // foreign key for the Kid navigation property   // // primary key in kid class

        public Course? Course { get; set; }  // Course navigation property
        public Kid? Kid { get; set; }    // Kid navigation property
    }
}

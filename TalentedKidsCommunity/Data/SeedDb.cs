using TalentedKidsCommunity.Models;

namespace TalentedKidsCommunity.Data
{
    public class SeedDb
    {
        public static void Seed(CenterContext context)
        {
            // checking the database for any existing Kid.
            if (context.Kids.Any())
            {
                return;   // DB has been seeded
            }

            var Kids = new Kid[]
            {
                new Kid{FirstName="Carson",LastName="Alexander",Age=10,EnrollmentDate=DateTime.Parse("2024-09-01")},
                new Kid{FirstName="Arturo",LastName="Anand",Age=6,EnrollmentDate=DateTime.Parse("2022-10-01")},
                new Kid{FirstName="Gytis",LastName="Barzdukas",Age=8,EnrollmentDate=DateTime.Parse("2023-08-22")},
                new Kid{FirstName="Yan",LastName="Li",Age=7,EnrollmentDate=DateTime.Parse("2020-05-13")},
                new Kid{FirstName="Peggy",LastName="Justice",Age=9,EnrollmentDate=DateTime.Parse("2024-07-04")},
                new Kid{FirstName="Laura",LastName="Norman",Age=10,EnrollmentDate=DateTime.Parse("2023-02-11")},
                new Kid{FirstName="Nino",LastName="Olivetto",Age=11,EnrollmentDate=DateTime.Parse("2022-12-01")},
                new Kid{FirstName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2017-09-01")},

            };

            context.Kids.AddRange(Kids);
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course{CourseID=1050,Title="Swiming Course",CourseFee=50.00 ,CourseDay=CourseDay.Saturday},
                new Course{CourseID=4022,Title="Squash Course",CourseFee=60.00 ,CourseDay=CourseDay.Sunday},
                new Course{CourseID=4041,Title="Drawing Class",CourseFee=40.00 ,CourseDay=CourseDay.Tuesday},
                new Course{CourseID=1045,Title="Ballet Dance",CourseFee=70.00 ,CourseDay=CourseDay.Friday},
                new Course{CourseID=3141,Title="Programming Class",CourseFee=95.00 ,CourseDay=CourseDay.Thursday},
                new Course{CourseID=2021,Title="Sign Language",CourseFee = 30.00, CourseDay = CourseDay.Saturday},
                new Course{CourseID=2042,Title="Piano Lessons",CourseFee = 45.00, CourseDay = CourseDay.Sunday},
                new Course{CourseID=2046,Title="Violin Lessons",CourseFee = 55.00, CourseDay = CourseDay.Monday},
                new Course{CourseID=2066,Title="Te Reo Maori",CourseFee = 50.00, CourseDay = CourseDay.Friday},
            };

            context.Courses.AddRange(courses);
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment{KidID=1,CourseID=1050},
                new Enrollment{KidID=1,CourseID=4022},
                new Enrollment{KidID=1,CourseID=4041},
                new Enrollment{KidID=2,CourseID=1045},
                new Enrollment{KidID=2,CourseID=3141},
                new Enrollment{KidID=2,CourseID=2021},
                new Enrollment{KidID=3,CourseID=1050},
                new Enrollment{KidID=4,CourseID=2066},
                new Enrollment{KidID=4,CourseID=4022},
                new Enrollment{KidID=5,CourseID=4041},
                new Enrollment{KidID=6,CourseID=2046},
                new Enrollment{KidID=7,CourseID=3141},
            };

            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();
        }
    }
}

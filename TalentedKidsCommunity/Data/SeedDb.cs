using Microsoft.SqlServer.Server;
using System.Diagnostics;
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


            var alexander = new Kid { FirstName = "Carson", LastName = "Alexander", Age = 10, EnrollmentDate = DateTime.Parse("2024-09-01") };
            var anand = new Kid { FirstName = "Arturo", LastName = "Anand", Age = 6, EnrollmentDate = DateTime.Parse("2022-10-01") };
            var barzdukas = new Kid { FirstName = "Gytis", LastName = "Barzdukas", Age = 8, EnrollmentDate = DateTime.Parse("2023-08-22") };
            var li = new Kid { FirstName = "Yan", LastName = "Li", Age = 7, EnrollmentDate = DateTime.Parse("2020-05-13") };
            var justice = new Kid { FirstName = "Peggy", LastName = "Justice", Age = 9, EnrollmentDate = DateTime.Parse("2024-07-04") };
            var norman = new Kid { FirstName = "Laura", LastName = "Norman", Age = 10, EnrollmentDate = DateTime.Parse("2023-02-11") };
            var olivetto = new Kid { FirstName = "Nino", LastName = "Olivetto", Age = 11, EnrollmentDate = DateTime.Parse("2022-12-01") };
            var alonso = new Kid { FirstName = "Meredith", LastName = "Alonso", Age = 10, EnrollmentDate = DateTime.Parse("2017-09-01") };
            var Kids = new Kid[]
            {
                alexander,anand,barzdukas,li,justice,norman,olivetto,alonso
            };

            context.Kids.AddRange(Kids);

            var abercrombie = new Instructor
            {
                FirstName = "Kim",
                LastName = "Abercrombie",
                Talend = "Swiming",
                HireDate = DateTime.Parse("2020-03-11")
            };

            var fakhouri = new Instructor
            {
                FirstName = "Fadi",
                LastName = "Fakhouri",
                Talend = "Programming",
                HireDate = DateTime.Parse("2022-07-06")
            };

            var harui = new Instructor
            {
                FirstName = "Roger",
                LastName = "Harui",
                Talend = "Squash",
                HireDate = DateTime.Parse("2024-07-01")
            };

            var kapoor = new Instructor
            {
                FirstName = "Candace",
                LastName = "Kapoor",
                Talend = "Art",
                HireDate = DateTime.Parse("2021-01-15")
            };

            var zheng = new Instructor
            {
                FirstName = "Roger",
                LastName = "Zheng",
                Talend = "Ballet",
                HireDate = DateTime.Parse("2024-02-12")
            };

            var Williams = new Instructor
            {
                FirstName = "Kim",
                LastName = "Williams",
                Talend = "Maori",
                HireDate = DateTime.Parse("2023-02-12")
            };
            var Jones = new Instructor
            {
                FirstName = "Sara",
                LastName = "Jones",
                Talend = "Piano",
                HireDate = DateTime.Parse("2023-04-12")
            };

            var smith = new Instructor
            {
                FirstName = "Sue",
                LastName = "smith",
                Talend = "Sign language",
                HireDate = DateTime.Parse("2023-05-12")
            };

            var macmillan = new Instructor
            {
                FirstName = "Melanie",
                LastName = "Macmillan",
                Talend = "Piano",
                HireDate = DateTime.Parse("2023-01-12")
            };

            var instructors = new Instructor[]
            {
                abercrombie,
                fakhouri,
                harui,
                kapoor,
                zheng,
                Williams,
                Jones,
                macmillan,
                smith
            };

            context.AddRange(instructors);

            var centerAssignments = new CenterAssignment[]
            {
                new CenterAssignment {
                    Instructor = fakhouri,
                    Location = "Smith 17" },
                new CenterAssignment {
                    Instructor = harui,
                    Location = "Gowan 27" },
                new CenterAssignment {
                    Instructor = kapoor,
                    Location = "Thompson 304" }
            };

            context.AddRange(centerAssignments);

            

            
       
            var sports = new Department
            {
                DepartmentName = "Sports",
                Administrator = abercrombie
            };

            var computer = new Department
            {
                DepartmentName = "Coumputer",
                Administrator = fakhouri
            };

            var art = new Department
            {
                DepartmentName = "Art",
                Administrator = kapoor
            };

            var dance = new Department
            {
                DepartmentName = "Dance",
                Administrator = zheng
            };

            var languages = new Department
            {
                DepartmentName = "Languages",
                Administrator = Williams
            };

            var music = new Department
            {
                DepartmentName = "Music",
                Administrator = Jones
            };

            var departments = new Department[]
            {
                sports, computer, art, dance, languages, music
            };


            context.AddRange(departments);



            var swiming = new Course { CourseID = 1050, Title = "Swiming Course", CourseFee = 50.00, CourseDay = CourseDay.Saturday, Department = sports, Instructors = new List<Instructor> { abercrombie } };
            var squash = new Course { CourseID = 4022, Title = "Squash Course", CourseFee = 60.00, CourseDay = CourseDay.Sunday, Department = sports, Instructors = new List<Instructor> { harui } };
            var drawing = new Course { CourseID = 4041, Title = "Drawing Class", CourseFee = 40.00, CourseDay = CourseDay.Tuesday, Department = art, Instructors = new List<Instructor> { kapoor } };
            var ballet = new Course { CourseID = 1045, Title = "Ballet Dance", CourseFee = 70.00, CourseDay = CourseDay.Friday, Department = dance, Instructors = new List<Instructor> { zheng } };
            var programming = new Course { CourseID = 3141, Title = "Programming Class", CourseFee = 95.00, CourseDay = CourseDay.Thursday, Department = computer, Instructors = new List<Instructor> { fakhouri } };
            var sign = new Course { CourseID = 2021, Title = "Sign Language", CourseFee = 30.00, CourseDay = CourseDay.Saturday, Department = languages, Instructors = new List<Instructor> { smith } };
            var piano = new Course { CourseID = 2042, Title = "Piano Lessons", CourseFee = 45.00, CourseDay = CourseDay.Sunday, Department = music, Instructors = new List<Instructor> { Jones } };
            var violin = new Course { CourseID = 2046, Title = "Violin Lessons", CourseFee = 55.00, CourseDay = CourseDay.Monday, Department = music, Instructors = new List<Instructor> { macmillan } };
            var maori = new Course { CourseID = 2066, Title = "Te Reo Maori", CourseFee = 50.00, CourseDay = CourseDay.Friday, Department = languages, Instructors = new List<Instructor> { Williams } };
            var courses = new Course[]
            {
                swiming,squash,drawing,ballet,programming,sign,piano,violin,maori
            };

            context.Courses.AddRange(courses);

            var enrollments = new Enrollment[]
            {
                new Enrollment{ Kid= alexander, Course=swiming},
                new Enrollment{ Kid=anand, Course=squash},
                new Enrollment{ Kid=barzdukas, Course=drawing},
                new Enrollment{ Kid=li, Course=ballet,},
                new Enrollment{ Kid=justice, Course=programming},
                new Enrollment{ Kid=norman,Course=sign},
                new Enrollment{ Kid = olivetto,Course=piano},
                new Enrollment{ Kid = alonso,Course=violin},
                new Enrollment{ Kid =li,Course=maori},
                new Enrollment{ Kid =alonso,Course=swiming},
                new Enrollment{ Kid = olivetto,Course=programming},
                new Enrollment{ Kid = justice,Course=maori},
            };

            context.Enrollments.AddRange(enrollments);

            context.SaveChanges();
        }
    }
}

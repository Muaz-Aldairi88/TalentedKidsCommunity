using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TalentedKidsCommunity.Data;
using TalentedKidsCommunity.Models;

namespace TalentedKidsCommunity.Pages.Instructors
{
    public class IndexModel : PageModel
    {
        private readonly TalentedKidsCommunity.Data.CenterContext _context;

        public IndexModel(TalentedKidsCommunity.Data.CenterContext context)
        {
            _context = context;
        }

        // instructor data view model
        public InstructorIndexData InstructorData { get; set; }
        public int InstructorID { get; set; }
        public int CourseID { get; set; }

        public async Task OnGetAsync(int? id, int? courseID)
        {
            InstructorData = new InstructorIndexData();
            InstructorData.Instructors = await _context.Instructors
                .Include(i => i.CenterAssignment)
                .Include(i => i.Courses)
                    .ThenInclude(c => c.Department)
                .OrderBy(i => i.LastName)
                .ToListAsync();

            // when the instructor is selected
            if (id != null)
            {
                InstructorID = id.Value;
                Instructor instructor = InstructorData.Instructors
                    .Where(i => i.InstructorID == id.Value).Single();// retriving the selected instructor (with spicific id) from the list of instructors // Single method is called to convert the collection into a single Instructor entity
                InstructorData.Courses = instructor.Courses;       
            }

            // // when the course is selected
            if (courseID != null)
            {
                CourseID = courseID.Value;
                IEnumerable<Enrollment> Enrollments = await _context.Enrollments
                    .Where(x => x.CourseID == CourseID)
                    .Include(i => i.Kid)
                    .ToListAsync();
                InstructorData.Enrollments = Enrollments;
            }
        }
    }
}

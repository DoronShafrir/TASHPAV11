using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TASHPAV11.Mapping;
using TASHPAV11.Model;

namespace TASHPAV11.Pages.Students
{
    public class MangeMyCoursesModel : PageModel
    {

        public string active_input { get; set; }
        public string submitNewButton { get; set; }
        public string delete_input { get; set; }
        public string deleteButton { get; set; }
        public string msg { get; set; }
        //public string List { get; set; }
        public string DisplayList { get; set; }
        public string insertMSG { get; set; }
        public string insert_button { get; set; }
        public string deleteMSG { get; set; }
        public Studentss List { get; set; } = new Studentss();
        public Student Student { get; set; } = new Student();
        [BindProperty]
        public Coursess courseList { get; set; } = new Coursess();
        [BindProperty]
        public int CourseToAdd { get; set; }



        public void OnGet()
        {
            active_input = "display:none";
            submitNewButton = "display:none";
            DisplayList = "display:block";
            delete_input = "display:none";
            deleteButton = "display:none";
            StudentsDB db = new StudentsDB();
            List = db.SelectAll();
            

        }
        public void OnPostRenderCourses()
        {
            active_input = "display:none";
            submitNewButton = "display:none";
            DisplayList = "display:block";
            delete_input = "display:none";
            deleteButton = "display:none";
            StudentsDB db = new StudentsDB();
            List = db.SelectAll();
        }

        public void OnPostShowAddCourses()
        {
            DisplayList = "display:none";
            active_input = "display:block";
            insert_button = "display:block";
            delete_input = "display:none";
            deleteButton = "display:none";
            CoursesDB courseList = new CoursesDB();
            this.courseList = courseList.SelectAll();
        }
        public void OnPostShowDeleteCourse()
        {
            DisplayList = "display:none";
            active_input = "display:none";
            insert_button = "display:none";
            delete_input = "display:block";
            deleteButton = "display:block";
        }
        public void OnPostInsertCourse(int CourseToAdd)
        {
            
            

            StudentsDB db = new StudentsDB();
            int records = db.Insert(CourseToAdd);
            delete_input = "display:none";
            deleteButton = "display:none";
            if (records == 1)
            {
                insert_button = "disply:none";
                insertMSG = "Course Added Successfuly";
            }
            else { insertMSG = "Could Not Add Course !!!"; }
            ;
        }
    }
}



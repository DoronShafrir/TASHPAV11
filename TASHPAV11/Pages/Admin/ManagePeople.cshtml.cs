using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TASHPAV11.Mapping;
using TASHPAV11.Model;

namespace TASHPAV11.Pages.Admin
{
    
    public class ManagePeopeleModel : PageModel
    {
        
        public People List{ get; set; } = new People();
        public Person person { get; set; } = new Person();
        public void OnGet()
        {
            int done = 0;
            AdminDB dB = new AdminDB();
            List = dB.SelectAllPeople();
        }
        public void OnPostToggleTeacherStudent(int TeacherToToggle) {
            AdminDB dB = new AdminDB();
            dB.ToggleTeacherStudent(TeacherToToggle);
            List = dB.SelectAllPeople();   
        }
    }
}

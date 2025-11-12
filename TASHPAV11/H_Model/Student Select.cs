using TASHPAV11.Model;

namespace TASHPAV11.H_Model
{
    public class Student_Select : Course
    {
        public int Id { get; set; }
        public int SId { get; set; }
        public int CourseId { get; set; }
        public string TeacherName { get; set; }
    }

    public class Studentss_Select : List<Student_Select>
    {
        public Studentss_Select() { }

        public Studentss_Select(IEnumerable<Student> list) : base((IEnumerable<Student_Select>)list) { }
    }
}


namespace TASHPAV11.Model
{
    public class Course : Person
    {
        public int CId { get; set; }
        public string CourseName { get; set; }
        public string CourseNumber { get; set; }
        public int ResponsibleTeacher { get; set; }

    }

    public class Coursess : List<Course>
    {
        public Coursess() { }

        public Coursess(IEnumerable<Course> list)
            : base(list)
        {

        }
    }
}

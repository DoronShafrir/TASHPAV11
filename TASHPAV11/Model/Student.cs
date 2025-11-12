namespace TASHPAV11.Model
{
    public class Student : Course
    {
        public int Id { get; set; }
        public int SId { get; set; }
        public int CourseId { get; set; }
        
    }

    public class Studentss : List<Student>
    {
        public Studentss() { }

        public Studentss(IEnumerable<Student> list) : base(list) { }
    }
}

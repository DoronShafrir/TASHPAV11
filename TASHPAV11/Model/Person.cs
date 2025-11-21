namespace TASHPAV11.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; }
        public bool Teacher { get; set; }
    }
    public class People : List<Person>
    {
        public People() { }
        public People(IEnumerable<Person> list)
                : base(list) { }
    }
}

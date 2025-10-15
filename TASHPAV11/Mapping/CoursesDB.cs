using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using TASHPAV11.App_Code;
using TASHPAV11.Model;

namespace TASHPAV11.Mapping
{
    public class CoursesDB
    {
        private readonly string connectionString = Imp_Data.ConString;



        public Coursess SelectAll()
        {
            Coursess courses = new Coursess();
            const string sql = "SELECT Courses.CId, Courses.CourseName, Courses.CourseNumber, Person.Name " +
                "FROM Courses INNER JOIN Person ON Courses.ResponsibleTeacher=Person.Id;";
            using var connection = new OleDbConnection(connectionString);
            using var command = new OleDbCommand(sql, connection);

            connection.Open();

            using var reader = command.ExecuteReader();

            while (reader!.Read())
            {
                Course course = new Course();
                course = new Course
                {
                    CId = int.Parse(reader["CId"].ToString()),
                    CourseName = reader["CourseName"].ToString(),
                    CourseNumber = reader["CourseNumber"].ToString(),
                    Name = reader["Name"].ToString()
                };
                courses.Add(course);
            }
            return courses;
        }






        //public string RenderAllCourses()
        //{
        //    Coursess courses = SelectAll();
        //    string RenderTable = "";
        //    foreach (var item in courses)
        //    {
        //        RenderTable += this.CreateTableLIne(item);
        //        RenderTable += "<br>";
        //    }
        //    return RenderTable;
        //}
        //public string CreateTableLIne(Course item)
        //{
        //    string coursesList = "";
        //    coursesList += item.CourseName.ToString() + "  ";
        //    coursesList += item.CourseNumber.ToString() + "  ";
        //    coursesList += item.Name.ToString() + "  ";
        //    return coursesList;
        //}
        public int Insert(Course course)
        {
            int records = 0;
            string arg1 = course.CourseName;
            string arg2 = course.CourseNumber;
            int arg3 = CheckName(course.Name);
            if (!(arg3 > 0)) return 0;
            
            string sql = $"INSERT INTO Courses (CourseName, CourseNumber, ResponsibleTeacher) " + 
                $"VALUES('{arg1}','{arg2}', {arg3}) ";
            using var connection = new OleDbConnection(connectionString);
            using var command = new OleDbCommand(sql, connection);
            connection.Open();

            records = (int)command.ExecuteNonQuery();

            return records;
        }

        public int DeleteCourse(Course course)
        {
            int records = 0;
            string arg1 = course.CourseName;
            string arg2 = course.CourseNumber;
            int arg3 = course.ResponsibleTeacher;
            //if (!(arg3 > 0)) return 0;

            string sql = "DELETE FROM Courses  " +
                $"WHERE CourseName ='{arg1}' OR CourseNumber = '{arg2}' OR ResponsibleTeacher = {arg3}; ";

            using var connection = new OleDbConnection(connectionString);
            using var command = new OleDbCommand(sql, connection);

            connection.Open();

            records = command.ExecuteNonQuery();
            
            
            return records;
        }

        public int CheckName(string name)
        {
            int recordId = 0;
            string sql = $"SELECT Id FROM Person WHERE Name = '{name}';";
            using var connection = new OleDbConnection(connectionString);
            using var command = new OleDbCommand(sql, connection);
            connection.Open();
                recordId = (int)command.ExecuteScalar();
           
            return recordId;
        }
    }
}

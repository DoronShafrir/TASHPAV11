using System.Data.OleDb;
using System.Security.Cryptography;
using System.Xml.Linq;
using TASHPAV11.App_Code;
using TASHPAV11.H_Model;
using TASHPAV11.Model;

namespace TASHPAV11.Mapping
{
    public class StudentsDB
    {
        private readonly string connectionString = Imp_Data.ConString;
       
         
        public Studentss_Select SelectAll()
        {
            int SId = SIdP.StudentId;
            Studentss_Select students = new Studentss_Select();
            Student_Select student = new Student_Select();
            int count = 0;
            string sql1 = $"SELECT student_person.[Id] AS StudentId, student_person.[Name] AS StudentName, " +
               "c.[CourseName], teacher_person.[Name] AS TeacherName " +
               "FROM (([Student] " +
               "INNER JOIN [Person] AS student_person ON [Student].[SId] = student_person.[Id]) " +
               "INNER JOIN [Courses] AS c ON [Student].[CourseId] = c.[CId]) " +
                " INNER JOIN [Person] AS teacher_person ON c.[ResponsibleTeacher] = teacher_person.[Id]"; 
            string sql2 = $"WHERE  student_person.[Id] = {SId};";
            string sql = sql1 + sql2;
            using var connection = new OleDbConnection(connectionString);
            using var command = new OleDbCommand(sql, connection);

            connection.Open();

            using var reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                count++;
               student = new Student_Select()
                {
                    Id = (int)reader["StudentId"],
                    Name = reader["StudentName"].ToString(),
                    CourseName = reader["CourseName"].ToString(),
                   TeacherName = reader["TeacherName"].ToString()

               };
             students.Add(student);
            }
            return students;
        }


        public int Insert(int CourseId)
        {
            int SId = SIdP.StudentId;
            int records = 0;
            int arg1 = SId;
            int arg2 = CourseId;
            if (arg1 != 0 && arg2 != 0)
            { 
            string sql = $"INSERT INTO Student (SId, CourseId) VALUES ({arg1},{arg2})";
            using var connection = new OleDbConnection(connectionString);
            using var command = new OleDbCommand(sql, connection);
            connection.Open();

            records = (int)command.ExecuteNonQuery();
            }
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


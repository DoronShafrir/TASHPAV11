using System;
using System.Data.OleDb;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using TASHPAV11.App_Code;
using TASHPAV11.Model;

namespace TASHPAV11.Mapping
{
    public class AdminDB
    {
        private readonly string connectionString = Imp_Data.ConString;

        public People SelectAllPeople()
        {
            People people = new People();
            const string sql = "SELECT * FROM [Person];";
            using var connection = new OleDbConnection(connectionString);
            using var command = new OleDbCommand(sql, connection);

            connection.Open();

            using var reader = command.ExecuteReader();

            while (reader!.Read())
            {
                Person person = new Person();
                person = new Person
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Name = reader["Name"].ToString(),
                    FName = reader["FName"].ToString(),
                    UserName = reader["UserName"].ToString(),
                    Password = reader["Password"].ToString(),
                    Admin = bool.Parse(reader["Admin"].ToString()),
                    Teacher = bool.Parse(reader["Teacher"].ToString()),
                };
                people.Add(person);
            }
            return people;
        }
        public int ToggleTeacherStudent(int TeacherToToggle)
        {
           int done = 0;

            const string sql = "UPDATE Person SET [Teacher] = NOT [Teacher] WHERE Id = ?;";
            using var connection = new OleDbConnection(connectionString);
            using var command = new OleDbCommand(sql, connection);
            using (OleDbCommand cmd = new OleDbCommand(sql, connection))
            {
                // ORDER MATTERS in OleDb (positional parameters)
               cmd.Parameters.AddWithValue("?", TeacherToToggle.ToString());

                connection.Open();
                done = cmd.ExecuteNonQuery();
            }               

            return done;

        }
    }
}

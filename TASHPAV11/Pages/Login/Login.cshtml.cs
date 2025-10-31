using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Data;
using System.Data.OleDb;
using System.Security.Cryptography;
using TASHPAV11.App_Code;
using TASHPAV11.H_Model;
using TASHPAV11.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;
//using System.Data.SqlClient;
//using Tashpa11.Model;

namespace TASHPAV11.Pages.Login
{
    public class LoginModel : PageModel
    {
        public string msg { get; set; }

        public void OnGet()
        {
        }
        public IActionResult OnPost(string userName, string password)
        {

            string connectionString = Imp_Data.ConString;
            //string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\USER\\OneDrive\\DSH\\Doron\\sources\\repos\\TASHPAV11\\TASHPAV11\\App_Data\\LoginDB.accdb;Persist Security Info=True";
            OleDbConnection con = new(connectionString);
            
            // בניית פקודת SQL
            string SQLStr = $"SELECT * FROM [Person] WHERE [UserName] = '{userName}' AND [Password] = '{password}';";
            OleDbCommand cmd = new(SQLStr, con);
            //If you want to make it safly against SQL Injection, use parameters like this: so make [USERNAME]=?
            //cmd.Parameters.Add("?", OleDbType.VarWChar, 255).Value = UserName?.Trim();

            //// בניית DataSet וטעינה
            //using var adapter = new OleDbDataAdapter(cmd);

            // בניית DataSet
            DataSet ds = new DataSet();

            // טעינת הנתונים
            OleDbDataAdapter adapter = new(cmd);
            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds, "names");

            int count = ds.Tables[0].Rows.Count;
            if (count > 0)

            {

                Person person = new Person();
                person.PId = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                person.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                person.FName = ds.Tables[0].Rows[0]["FName"].ToString();
                person.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                person.Admin = bool.Parse(ds.Tables[0].Rows[0]["Admin"].ToString());
                string IsAdmin = person.Admin == true ? "Admin" : "NotAdmin";
                int SId = person.Teacher == true ? 0 : person.PId;
               
                SIdP.StudentId = SId;

                HttpContext.Session.SetString("Admin", IsAdmin);


                HttpContext.Session.SetString("Username", person.UserName);
                HttpContext.Session.SetString("FirstName", person.Name);
                HttpContext.Session.SetString("LastName", person.FName);
                HttpContext.Session.SetString("SId", SId.ToString());
                return RedirectToPage("/Index");
            }
            else
            {
                msg = "Wrong username or password";
                return Page();
            }
                        

        }
        


    }
}
    

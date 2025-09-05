using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.OleDb;
using TASHPAV11.Model;
using System;
using System.Data;
using TASHPAV11.App_Code;
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
            OleDbConnection con = new(connectionString);
            
            // בניית פקודת SQL
            string SQLStr = $"SELECT * FROM Person WHERE UserName = '{userName}' AND Password = '{password}';";
            OleDbCommand cmd = new(SQLStr, con);

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
                person.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                person.FName = ds.Tables[0].Rows[0]["FName"].ToString();
                person.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                person.Admin = bool.Parse(ds.Tables[0].Rows[0]["Admin"].ToString());
                string IsAdmin = person.Admin == true ? "Admin" : "NotAdmin";

                HttpContext.Session.SetString("Admin", IsAdmin);


                HttpContext.Session.SetString("Username", person.UserName);
                HttpContext.Session.SetString("FirstName", person.Name);
                HttpContext.Session.SetString("LastName", person.FName);

                return RedirectToPage("/Index");
            }
            else
            {
                msg = "Wrong username or password";
                return Page();
            }

            //this.UserName = HttpContext.Session.GetString("FirstName").ToString();
            //this.Password = HttpContext.Session.GetString("LastName").ToString();
            //bool b = HttpContext.Session.GetString("FirstName").ToString().IsNullOrEmpty();


        }
        //        catch
        //        {
        //            return RedirectToPage("/Index");
        //}


    }
}
    

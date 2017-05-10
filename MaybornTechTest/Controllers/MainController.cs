using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaybornTechTest.Controllers
{
    public class MainController : Controller
    {
        //
        // GET: /Main/
        public ActionResult Index()
        {
            return View();
        }

        // Would have used Repository Design Pattern if DatabaseContext was being called/used 
        // Simple methods one read and one write
        public void AppendTextFile(string firstName, string lastName)
        {
            // Text File should be saved in the IIS Express location
            string textToAppend = "First Name - " + firstName + "\n" + "Last Name - " + lastName + "\n\n";
            System.IO.File.AppendAllText("Data.txt", textToAppend);
        }

        public JsonResult GetTextFileContents()
        {
            var contents = new List<object>();

            // Had a problem with formatting using ReadAllLines wasn't seeing /n so split the lines into an array
            // Returns json as per AJAX
            try
            {
                string[] content = System.IO.File.ReadAllLines("Data.txt");
                foreach (string s in content)
                {
                    contents.Add(new { Data = s + "\n" });
                }
            }
            catch
            {
                // File Doesn't Exist Currently
            }
            return Json(contents, JsonRequestBehavior.AllowGet);
        }
    }
}

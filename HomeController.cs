using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Text.RegularExpressions;

namespace Calculator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Models.Calculator c)
        {

            string test = c.result;
            //string[] words = c.result.Split(new char[] { '+', '-', '*', '/' }, StringSplitOptions.None);
           
            double result=0;
            string s = c.result;
            
           

            if (s.IndexOf('+') > 0) {
                string first = s.Substring(0, s.IndexOf('+'));
                string second = s.Substring(s.IndexOf('+') + 1);
                int a = Convert.ToInt32(first);
                int b = Convert.ToInt32(second);
                result = a + b;
            }
            else if (s.IndexOf('-') > 0)
            {
                string first = s.Substring(0, s.IndexOf('-'));
                string second = s.Substring(s.IndexOf('-') + 1);
                int a = Convert.ToInt32(first);
                int b = Convert.ToInt32(second);
                result = a - b;
            }
            else if (s.IndexOf('*') > 0)
            {
                string first = s.Substring(0, s.IndexOf('*'));
                string second = s.Substring(s.IndexOf('*') + 1);
                int a = Convert.ToInt32(first);
                int b = Convert.ToInt32(second);
                result = a * b;
            }
            else if (s.IndexOf('/') > 0)
            {
                string first = s.Substring(0, s.IndexOf('/'));
                string second = s.Substring(s.IndexOf('/') + 1);
                int a = Convert.ToInt32(first);
                int b = Convert.ToInt32(second);
                result = a / b;
            }
            else
            {

                Console.WriteLine("this is non-case");
            }


            //switch (index)
            //{
            //    case 1:
            //        result = a + b;
            //        break;
            //    case "-":
            //        result = a - b;
            //        break;
            //    case "*":
            //        result = a * b;
            //        break;
            //    case "/":
            //        result = a / b;
            //        break;
            //    default:
            //        Console.WriteLine("non-case");
            //        break;
            //}

            string path = Server.MapPath(@"~/App_Data/file.txt");

            
            if (!System.IO.File.Exists(path))
            {
              
                string createText = "Hello and Welcome" + Environment.NewLine;
                System.IO.File.WriteAllText(path, createText);
            }

            
            string appendText = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + " " + c.result+"=" + (result).ToString() + " " + Environment.NewLine;
            System.IO.File.AppendAllText(path, appendText);


            //string readText = System.IO.File.ReadAllText(path);
            ViewBag.result = result;
            return View();
        }

       
    
    }
}
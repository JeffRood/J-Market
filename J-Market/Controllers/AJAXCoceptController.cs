using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace J_Market.Controllers
{
    public class AJAXCoceptController : Controller
    {
        // GET: AJAXCocept
        public ActionResult Index()
        {
            return View();
        }

    public  JsonResult JsonFactorial(int n)
        {
            if (!Request.IsAjaxRequest())
            {
                return null;
            }

            var result = new JsonResult
            {
                // La propiedad data es una propiedad de json que contiene otro objecto
                Data = new { Factorial = Factorial(n)  }
            };
            return result;
        }

        private double Factorial(int n)
        {
            double Factorial = 1;

            for (int i = 2 ; i <= n; i++)
            {
                Factorial *= i;
            
            }
            return Factorial;
        }
    }
}
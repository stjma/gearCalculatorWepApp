using gearCalculator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace gearCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        //RatioCalculator
        public IActionResult RatioCalculator()
        {
           
            return View();
        }


        [HttpPost]
        public ActionResult RatioCalculator(GearViewModel model)
        {
            List<List<string>> completeRatio = new List<List<string>>();
            //validation max bigger than min
            //string[,] test = { { model.Chainringmin, model.Chainringmax} , {model.Cogmin, model.Cogmax } };


            List<string> firstRow = new List<string>();

            firstRow.Add(" ");
            for (int i = Int32.Parse(model.Chainringmin); i <= Int32.Parse(model.Chainringmax); i++)
            {
                firstRow.Add(i.ToString());
            }


            completeRatio.Add(firstRow);
            for (double i = Double.Parse(model.Cogmin); i <= Double.Parse(model.Cogmax); i++)
            {

                List<string> NextRow = new List<string>();
                NextRow.Add(i.ToString());
                for (double ii = Double.Parse(model.Chainringmin); ii <= Double.Parse(model.Chainringmax); ii++)
                {

                    //calcul.ToString()
                    double calcul = ii / i;
                    
                    NextRow.Add(Convert.ToDecimal(string.Format("{0:F2}", calcul)).ToString());

                    
                }
                completeRatio.Add(NextRow);
            }

            ViewBag.MyArray = completeRatio;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

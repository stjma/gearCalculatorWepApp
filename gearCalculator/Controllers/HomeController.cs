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

        public IActionResult Strava()
        {
            return View();
        }


        public IActionResult SpeedCalculator()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SpeedCalculator(SpeedViewModel model)
        {
            List<List<string>> completeRatio = new List<List<string>>();

            if (model.Chainringmax != null && model.Chainringmin != null && model.Cogmax != null
                && model.Cogmin != null && model.RimeSize != null && model.TireSize != null && model.Cadence != null)
            {
                
                double wheelDiameter = (((Double.Parse(model.RimeSize)) + (Double.Parse(model.TireSize) * 2)) * (Math.PI)) *(0.0000373) * (Double.Parse(model.Cadence));

                int chMax = Int32.Parse(model.Chainringmax);
                int chMin = Int32.Parse(model.Chainringmin);

                int cMax = Int32.Parse(model.Cogmax);
                int cMin = Int32.Parse(model.Cogmin);

                if (chMax <= chMin && cMax <= cMin)
                {
                    ModelState.Clear();
                    model.Chainringmax = chMin.ToString();
                    model.Chainringmin = chMax.ToString();


                    model.Cogmax = cMin.ToString();
                    model.Cogmin = cMax.ToString();
                }
                else if (chMax <= chMin)
                {
                    ModelState.Clear();
                    model.Chainringmax = chMin.ToString();
                    model.Chainringmin = chMax.ToString();

                    model.Cogmax = cMax.ToString();
                    model.Cogmin = cMin.ToString();
                }
                else if (cMax <= cMin)
                {
                    ModelState.Clear();
                    model.Chainringmax = chMax.ToString();
                    model.Chainringmin = chMin.ToString();

                    model.Cogmax = cMin.ToString();
                    model.Cogmin = cMax.ToString();
                }


                List<string> firstRow = new List<string>();
                firstRow.Add("");
                for (int i = Int32.Parse(model.Chainringmin); i <= Int32.Parse(model.Chainringmax); i++)
                {
                    firstRow.Add(i.ToString());
                }
                firstRow.Add("");

                completeRatio.Add(firstRow);
                for (double i = Double.Parse(model.Cogmin); i <= Double.Parse(model.Cogmax); i++)
                {

                    List<string> NextRow = new List<string>();
                    NextRow.Add(i.ToString());
                    for (double ii = Double.Parse(model.Chainringmin); ii <= Double.Parse(model.Chainringmax); ii++)
                    {

                        if(Int32.Parse(model.KpmOrMph) == 1)
                        {
                            double calcul = wheelDiameter * (ii / i);

                            NextRow.Add(Convert.ToDecimal(string.Format("{0:F2}", calcul)).ToString());
                        }
                        else if (Int32.Parse(model.KpmOrMph) == 2)
                        {
                            double calcul = (wheelDiameter * (ii / i)) * 1.609;

                            NextRow.Add(Convert.ToDecimal(string.Format("{0:F2}", calcul)).ToString());
                        }




                    }
                    NextRow.Add(i.ToString());
                    completeRatio.Add(NextRow);
                }
                completeRatio.Add(firstRow);
                ViewBag.MyArray = completeRatio;
                return View(model);

            }
            return View();
        }

        public IActionResult MeterCalculator()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MeterCalculator(MeterViewModel model)
        {
            List<List<string>> completeRatio = new List<List<string>>();

            if (model.Chainringmax != null && model.Chainringmin != null && model.Cogmax != null
                && model.Cogmin != null && model.RimeSize != null && model.TireSize != null)
            {

                double wheelDiameter = (((Double.Parse(model.RimeSize) / 1000) + ((Double.Parse(model.TireSize) / 1000) * 2)) * Math.PI);

                int chMax = Int32.Parse(model.Chainringmax);
                int chMin = Int32.Parse(model.Chainringmin);

                int cMax = Int32.Parse(model.Cogmax);
                int cMin = Int32.Parse(model.Cogmin);

                if (chMax <= chMin && cMax <= cMin)
                {
                    ModelState.Clear();
                    model.Chainringmax = chMin.ToString();
                    model.Chainringmin = chMax.ToString();


                    model.Cogmax = cMin.ToString();
                    model.Cogmin = cMax.ToString();
                }
                else if (chMax <= chMin)
                {
                    ModelState.Clear();
                    model.Chainringmax = chMin.ToString();
                    model.Chainringmin = chMax.ToString();

                    model.Cogmax = cMax.ToString();
                    model.Cogmin = cMin.ToString();
                }
                else if (cMax <= cMin)
                {
                    ModelState.Clear();
                    model.Chainringmax = chMax.ToString();
                    model.Chainringmin = chMin.ToString();

                    model.Cogmax = cMin.ToString();
                    model.Cogmin = cMax.ToString();
                }


                List<string> firstRow = new List<string>();
                firstRow.Add("");
                for (int i = Int32.Parse(model.Chainringmin); i <= Int32.Parse(model.Chainringmax); i++)
                {
                    firstRow.Add(i.ToString());
                }
                firstRow.Add("");

                completeRatio.Add(firstRow);
                for (double i = Double.Parse(model.Cogmin); i <= Double.Parse(model.Cogmax); i++)
                {

                    List<string> NextRow = new List<string>();
                    NextRow.Add(i.ToString());
                    for (double ii = Double.Parse(model.Chainringmin); ii <= Double.Parse(model.Chainringmax); ii++)
                    {


                        double calcul = wheelDiameter * (ii / i);

                        NextRow.Add(Convert.ToDecimal(string.Format("{0:F2}", calcul)).ToString());


                    }
                    NextRow.Add(i.ToString());
                    completeRatio.Add(NextRow);
                }
                completeRatio.Add(firstRow);
                ViewBag.MyArray = completeRatio;
                return View(model);

            }
            return View();
        }

        public IActionResult RatioCalculator()
        {
            
            return View();
        }


        [HttpPost]
        public ActionResult RatioCalculator(GearViewModel model)
        {

            List<List<string>> completeRatio = new List<List<string>>();

            if (model.Chainringmax != null && model.Chainringmin != null && model.Cogmax != null && model.Cogmin != null)
            {
                int chMax = Int32.Parse(model.Chainringmax);
                int chMin = Int32.Parse(model.Chainringmin);

                int cMax = Int32.Parse(model.Cogmax);
                int cMin = Int32.Parse(model.Cogmin);

                if (chMax <= chMin && cMax <= cMin)
                {
                    ModelState.Clear();
                    model.Chainringmax = chMin.ToString();
                    model.Chainringmin = chMax.ToString();


                    model.Cogmax = cMin.ToString();
                    model.Cogmin = cMax.ToString();
                }
                else if (chMax <= chMin)
                {
                    ModelState.Clear();
                    model.Chainringmax = chMin.ToString();
                    model.Chainringmin = chMax.ToString();

                    model.Cogmax = cMax.ToString();
                    model.Cogmin = cMin.ToString();
                }
                else if (cMax <= cMin)
                {
                    ModelState.Clear();
                    model.Chainringmax = chMax.ToString();
                    model.Chainringmin = chMin.ToString();

                    model.Cogmax = cMin.ToString();
                    model.Cogmin = cMax.ToString();
                }


                List<string> firstRow = new List<string>();
                firstRow.Add("");
                for (int i = Int32.Parse(model.Chainringmin); i <= Int32.Parse(model.Chainringmax); i++)
                {
                    firstRow.Add(i.ToString());
                }
                firstRow.Add("");

                completeRatio.Add(firstRow);
                for (double i = Double.Parse(model.Cogmin); i <= Double.Parse(model.Cogmax); i++)
                {

                    List<string> NextRow = new List<string>();
                    NextRow.Add(i.ToString());
                    for (double ii = Double.Parse(model.Chainringmin); ii <= Double.Parse(model.Chainringmax); ii++)
                    {


                        double calcul = ii / i;

                        NextRow.Add(Convert.ToDecimal(string.Format("{0:F2}", calcul)).ToString());


                    }
                    NextRow.Add(i.ToString());
                    completeRatio.Add(NextRow);
                }
                completeRatio.Add(firstRow);
                ViewBag.MyArray = completeRatio;
                return View(model);

            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

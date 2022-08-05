using InterfaceTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace InterfaceTask.Controllers
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

        public IActionResult Calculator()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Calculator(Data d)
        {
            FileStream fs = new FileStream("E:\\demo.txt", FileMode.OpenOrCreate, FileAccess.Write);
            try
            {
                d.sum = d.x + d.y;
                d.product = d.x * d.y;
                XmlSerializer xs = new XmlSerializer(typeof(Data));
                xs.Serialize(fs, d);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();

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

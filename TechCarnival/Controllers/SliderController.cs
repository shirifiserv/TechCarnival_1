using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechCarnival.Models;

namespace TechCarnival.Controllers
{
    public class SliderController : Controller
    {
        // GET: Slider
        public ActionResult Index()
        {
            string[] filePaths = System.IO.Directory.GetFiles(Server.MapPath("~/assets/img/"));
            List<Slider> files = new List<Slider>();
            foreach (string filePath in filePaths)
            {
                string fileName = Path.GetFileName(filePath);
                files.Add(new Slider
                {
                    title = fileName.Split('.')[0].ToString(),
                    src = "../assets/img/" + fileName
                });
            }
            return View(files);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineCV.Models;

namespace OnlineCV.Controllers
{
    public class SafeController : Controller
    {
        SafeModel Model { get; set; } = new SafeModel();
        public IActionResult Index(SafeModel model)
        {
            return View(Model);
        }

        public IActionResult OpenSafe(string[] productnumbers)
        {
            bool open = true;
            foreach(string s in productnumbers)
            {
                if(!Model.Productnumbers.Contains(s))
                {
                    open = false;
                    Model.NotFound.Add(s);
                }
            }
            Model.Open = open;
            return View("Index", Model);
        }

        public IActionResult Close()
        {
            Model.Open = false;
            return View("Index", Model);
        }
    }
}
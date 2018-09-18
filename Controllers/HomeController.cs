using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyfirstApi.Data;
using MyfirstApi.Models;

namespace MyfirstApi.Controllers
{
    public class HomeController : Controller
    {

        ApplicationDbContext applicationDbContext;

        public HomeController (ApplicationDbContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }

        //Display all
        public IActionResult Index()
        {
            var allproducts = applicationDbContext.Products.ToList();
            return View(allproducts);
        }


        //Delete
        [HttpGet]
        public IActionResult Delete(int Id)
        {

            Product P = applicationDbContext.Products.Find(Id);
            return View(P);
        }

        [HttpPost]
        public IActionResult Delete(Product P)
        {

            applicationDbContext.Remove<Product>(P);
            applicationDbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
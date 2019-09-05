using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Qualysoft.WebShop.ForKSB.Models;
using Qualysoft.WebShop.ForKSB.Services;

namespace Qualysoft.WebShop.ForKSB.Controllers
{
    public class QualysoftController : Controller
    {
        private readonly ICrudService _crud;

        public QualysoftController(ICrudService crud)
        {
            _crud = crud;
        }

        [HttpGet]
        public async Task<IActionResult> Products()
        {
            HttpContext.Session.Remove("Cart");
            var products = await _crud.GetProducts();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> AddToCart(int productId)
        {
            int userId = int.Parse(HttpContext.Session.GetString("Id"));
            await _crud.AddToCart(userId, productId);

            return RedirectToAction("Products");
        }

        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            if (HttpContext.Session.GetString("Id") == null)
                return RedirectToAction(nameof(Products));
            int userId = int.Parse(HttpContext.Session.GetString("Id"));
            HttpContext.Session.SetString("Cart","Cart");
            var products = await _crud.GetMyProducts(userId);
            return View("Products", products);
        }

        [HttpGet]
        public async Task<IActionResult> Events()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult BuyNow(int id)
        //{
        //    Random rnd = new Random(100000);
        //    double num = rnd.NextDouble();
        //    return View(num);
        //}


        [HttpGet]
        public async Task<IActionResult> Purchase()
        {
            Account acc = await _crud.GetAccountDetails(int.Parse(HttpContext.Session.GetString("Id")));
            return View(acc);
        }

        /*
        [HttpGet]
        public async Task<IActionResult> Delete(int productId)
        {
            int userId = int.Parse(HttpContext.Session.GetString("Id"));
            await _crud.Delete(userId, productId);

            return RedirectToAction("Products");
        }
        */
    }
}
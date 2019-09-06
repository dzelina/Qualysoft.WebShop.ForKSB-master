using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Qualysoft.WebShop.ForKSB.Models;
using Qualysoft.WebShop.ForKSB.Services;
using Qualysoft.WebShop.ForKSB.ViewModels;

namespace Qualysoft.WebShop.ForKSB.Controllers
{
    public class QualysoftController : Controller
    {
        private readonly ICrudService _crud;
        private readonly IApiService _api;

        public QualysoftController(ICrudService crud, IApiService api)
        {
            _crud = crud;
            _api = api;
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
            PurchaseViewModel pVM = new PurchaseViewModel();
            Account acc = await _crud.GetAccountDetails(int.Parse(HttpContext.Session.GetString("Id")));
            pVM.Account = acc;
            Random rnd = new Random();
            pVM.OrderNo = rnd.Next(0, 999999);
            return View(pVM);
        }


        [HttpGet]
        public IActionResult Delete(int productId)
        {
            int userId = int.Parse(HttpContext.Session.GetString("Id"));
            _crud.DeleteProductFromCart(userId, productId);

            return RedirectToAction("Products");
        }

        [HttpGet]
        public IActionResult CallBPM()
        {
            var response = _api.CallBPM();
            return View();
        }

    }
}
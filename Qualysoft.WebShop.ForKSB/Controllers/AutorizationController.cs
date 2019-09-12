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
    public class AutorizationController : Controller
    {
        
        private readonly ICrudService _crud;
        private readonly IPasswordHasher _pwdHash;

        public AutorizationController(ICrudService crud,IPasswordHasher pwdHash)
        {
            _crud = crud;
            _pwdHash = pwdHash;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View(new LoginViewModel());
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View(new RegisterViewModel());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                login.Password = _pwdHash.EncryptPass(login.Password); //hashovanje passworda 
                var account = await _crud.Login(login.Password, login.Email);
                HttpContext.Session.SetString("username", account.Username);
                HttpContext.Session.SetString("Id", account.Id.ToString());
                return RedirectToAction("Products", "Qualysoft");
            }

            return View("Login");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if(ModelState.IsValid)
            {
                register.Password = _pwdHash.EncryptPass(register.Password); // hashovanje passworda
                Account account = await _crud.Register(register.Username, register.Password, register.Email);
                HttpContext.Session.SetString("username", account.Username);
                HttpContext.Session.SetString("Id", account.Id.ToString());
                return RedirectToAction(nameof(Profile), account);
            }
            return View("Register");
        }

        [HttpGet]
        public async Task<IActionResult> Profile(Account account)
        {
            Account acc = account;
            if(account.Id == 0)
            {
                acc = await _crud.GetAccountDetails(int.Parse(HttpContext.Session.GetString("Id")));
            }
            return View(acc);
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile(int Id)
        {
            Account acc = await _crud.GetAccountDetails(Id);
            return View(acc);
        }
        

        [HttpPost]
        public async Task<IActionResult> EditProfile(Account acc)
        {
            await _crud.UpdateAccount(acc);
            return View(acc);
        }

        [HttpGet]
        public IActionResult SignOut()
        {
            HttpContext.Session.Remove("Id");
            HttpContext.Session.Remove("username");
            HttpContext.Session.Remove("Cart");
            
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> SubscribeWebinar()
        {
            return View();
        }


        
    }
}
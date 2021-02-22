using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationServices.IServices;
using DomainModels.Models;
using Lakotron.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Lakotron.Controllers
{
    public class UserController : Controller
    {
        private readonly IPaymentService _paymentService;

        private readonly IUserService _userService;

        private readonly IConfiguration _configuration;

        private readonly string approvedKeyWord = "ApprovedKeyWord";

        public UserController(IUserService userService, IPaymentService paymentService, IConfiguration configuration)
        {
            this._userService = userService;
            this._paymentService = paymentService;
            this._configuration = configuration;
        }

        [HttpGet]
        public IActionResult Donators()
        {
            var isAprroved = HttpContext.Session.Get(approvedKeyWord)?.ToString();
            if (string.IsNullOrEmpty(isAprroved))
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var donators = _userService.GetUserList();

            var viewModel = new DonatorsViewModel()
            {
                Donators = donators
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult UserInfo(int id)
        {
            var isAprroved = HttpContext.Session.Get(approvedKeyWord)?.ToString();
            if (string.IsNullOrEmpty(isAprroved))
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            var donator = _userService.GetUserById(id);

            var viewModel = new DonatorDetailsViewModel()
            {
                Message = donator.Message,
                Name = donator.Name,
                DonatedDate = donator.DonateTime
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult NewUser(int id)
        {
            var isAprroved = HttpContext.Session.Get(approvedKeyWord)?.ToString();
            if (string.IsNullOrEmpty(isAprroved))
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            else
            {
                return View(new UserInfoViewModel() { PaymentId = id });
            }
        }

        [HttpPost]
        public IActionResult CreateUser(UserInfoViewModel model)
        {
            var donator = new Donator()
            {
                Name = model.Name,
                Message = model.Message,
                DonateTime = DateTime.Now
            };

            var payment = _paymentService.GetPaymentById(model.PaymentId);

            _userService.AddUser(payment, donator);

            return RedirectToAction(nameof(Donators));
        }
    }
}

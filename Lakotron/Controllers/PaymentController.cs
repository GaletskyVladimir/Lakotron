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
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;

        private readonly IConfiguration _configuration;

        private readonly string approvedKeyWord = "ApprovedKeyWord";

        public PaymentController(IPaymentService paymentService, IConfiguration configuration)
        {
            this._paymentService = paymentService;
            this._configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index(PaymentViewModel model)
        {
            return View(model);
        }

        [HttpPost]
        public IActionResult Pay(PaymentViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    model.Error = ModelState.Values.First(x => x.Errors.Any()).Errors.First().ErrorMessage;
                    return View("Index", model);
                }

                var payment = new PaymentInfo()
                {
                    CardNumber = model.CardNumber,
                    Name = model.Name,
                    SecurityCode = model.SecurityCode,
                    ExpirationDate = model.ExpirationDate
                };

                var result = _paymentService.Pay(payment);
                var value = _configuration[approvedKeyWord];
                HttpContext.Session.SetString(approvedKeyWord, value);
                return RedirectToAction(nameof(UserController.NewUser), "User", new { id= result.ID });
            }
            catch (Exception ex)
            {
                return View("PaymentError");
            }
        }
    }
}

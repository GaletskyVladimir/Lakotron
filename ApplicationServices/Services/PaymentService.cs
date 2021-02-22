using ApplicationServices.IRepository;
using ApplicationServices.IServices;
using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationServices.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentInfoReporitory _paymentRepository;

        public PaymentService(IPaymentInfoReporitory paymentRepository)
        {
            this._paymentRepository = paymentRepository;
        }

        public PaymentInfo AddDonatorToPaymentInfo(int paymentId, Donator user)
        {
            return _paymentRepository.AddDonatorToPaymentInfo(paymentId, user);
        }

        public PaymentInfo GetPaymentById(int id)
        {
            return this._paymentRepository.GetPaymentById(id);
        }

        public PaymentInfo Pay(PaymentInfo payment)
        {
            // call to 3rd party payment provider
            payment.CardNumber = "****" + payment.CardNumber.Substring(4, 8) + "****";
            return _paymentRepository.AddPaymentInfo(payment);
        }
    }
}

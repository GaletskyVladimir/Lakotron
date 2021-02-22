using ApplicationServices.Containers;
using ApplicationServices.IRepository;
using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationServices.Repository
{
    public class PaymentInfoReporitory : IPaymentInfoReporitory
    {
        public PaymentInfo AddDonatorToPaymentInfo(int paymentId, Donator user)
        {
            return PaymentInfoContainer.AddDonatorToPaymentInfo(paymentId, user);
        }

        public PaymentInfo AddPaymentInfo(PaymentInfo payment)
        {
            return PaymentInfoContainer.AddPaymentInfo(payment);
        }

        public PaymentInfo GetPaymentById(int paymentId)
        {
            return PaymentInfoContainer.GetById(paymentId);
        }
    }
}

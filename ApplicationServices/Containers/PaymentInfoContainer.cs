using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationServices.Containers
{
    public static class PaymentInfoContainer
    {
        private static int currentPrimaryId = 1;

        private static List<PaymentInfo> payments { get; set; }

        static PaymentInfoContainer()
        {
            payments = new List<PaymentInfo>();
        }

        public static IEnumerable<PaymentInfo> GetAll() => payments;

        public static PaymentInfo AddPaymentInfo(PaymentInfo payment)
        {
            var savingPayment = new PaymentInfo(currentPrimaryId)
            {
                CardNumber = payment.CardNumber,
                SecurityCode = payment.SecurityCode,
                Name = payment.Name,
                DonatorId = payment.DonatorId,
                Donator = payment.Donator,
                ExpirationDate = payment.ExpirationDate
            };

            payments.Add(savingPayment);
            currentPrimaryId++;
            return savingPayment;
        }

        public static PaymentInfo GetById(int paymentId)
        {
            return payments.First(x => x.ID == paymentId);
        }

        public static PaymentInfo AddDonatorToPaymentInfo(int paymentId, Donator user)
        {
            var payment = payments.First(x => x.ID == paymentId);
            payment.Donator = user;
            payment.DonatorId = user.ID;
            return payment;
        }
    }
}

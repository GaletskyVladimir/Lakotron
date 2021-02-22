using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationServices.IRepository
{
    public interface IPaymentInfoReporitory
    {
        PaymentInfo AddPaymentInfo(PaymentInfo payment);

        PaymentInfo GetPaymentById(int paymentId);

        PaymentInfo AddDonatorToPaymentInfo(int paymentId, Donator user);
    }
}

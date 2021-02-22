using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationServices.IServices
{
    public interface IPaymentService
    {
        PaymentInfo Pay(PaymentInfo payment);

        PaymentInfo AddDonatorToPaymentInfo(int paymentId, Donator user);

        PaymentInfo GetPaymentById(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels.Models
{
    public class PaymentInfo
    {
        public PaymentInfo()
        {

        }

        public PaymentInfo(int id)
        {
            this.ID = id;
        }

        public int ID { get; set; }

        public string CardNumber { get; set; }

        public string ExpirationDate { get; set; }

        public int SecurityCode { get; set; }

        public string Name { get; set; }

        public Donator Donator { get; set; }

        public int DonatorId { get; set; }
    }
}

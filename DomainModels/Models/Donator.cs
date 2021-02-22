using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels.Models
{
    public class Donator
    {
        public Donator()
        {

        }

        public Donator(int donatorId)
        {
            this.ID = donatorId;
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public string Message { get; set; }

        public DateTime DonateTime { get; set; }
    }
}

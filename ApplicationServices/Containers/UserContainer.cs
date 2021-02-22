using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationServices.Containers
{
    public static class UserContainer
    {
        private static int currentPrimaryId = 1;

        private static List<Donator> users { get; set; }

        static UserContainer()
        {
            users = new List<Donator>();
        }

        public static IEnumerable<Donator> GetAll() => users;

        public static Donator GetById(int donatorId)
        {
            return users.First(x => x.ID == donatorId);
        }

        public static Donator AddDonator(Donator donator)
        {
            var savingDonator = new Donator(currentPrimaryId)
            {
                Message = donator.Message,
                Name = donator.Name,
                DonateTime = DateTime.Now
            };

            users.Add(savingDonator);
            currentPrimaryId++;
            return savingDonator;
        }
    }
}

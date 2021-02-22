using ApplicationServices.Containers;
using ApplicationServices.IRepository;
using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationServices.Repository
{
    public class UserRepository : IUserRepository
    {
        public Donator AddUser(Donator user)
        {
            return UserContainer.AddDonator(user);
        }

        public IEnumerable<Donator> GetAllUsers()
        {
            return UserContainer.GetAll();
        }

        public Donator GetUserById(int userId)
        {
            return UserContainer.GetById(userId);
        }
    }
}

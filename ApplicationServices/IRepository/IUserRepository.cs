using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationServices.IRepository
{
    public interface IUserRepository
    {
        Donator AddUser(Donator user);

        Donator GetUserById(int userId);

        IEnumerable<Donator> GetAllUsers();
    }
}

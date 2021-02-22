using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationServices.IServices
{
    public interface IUserService
    {
        Donator AddUser(PaymentInfo payment, Donator user);

        IEnumerable<Donator> GetUserList();

        Donator GetUserById(int userId);
    }
}

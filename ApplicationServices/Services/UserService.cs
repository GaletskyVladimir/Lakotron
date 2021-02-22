using ApplicationServices.IRepository;
using ApplicationServices.IServices;
using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationServices.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        private readonly IPaymentInfoReporitory _paymentRepository;

        public UserService(IUserRepository userRepository, IPaymentInfoReporitory paymentRepository)
        {
            this._userRepository = userRepository;
            this._paymentRepository = paymentRepository;
        }

        public Donator AddUser(PaymentInfo payment, Donator user)
        {
            var createdUser = _userRepository.AddUser(user);
            _paymentRepository.AddDonatorToPaymentInfo(payment.ID, createdUser);
            return createdUser;
        }

        public Donator GetUserById(int userId)
        {
            return _userRepository.GetUserById(userId);
        }

        public IEnumerable<Donator> GetUserList()
        {
            return _userRepository.GetAllUsers();
        }
    }
}

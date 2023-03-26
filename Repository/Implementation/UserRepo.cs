using Domain.Implementation;
using Domain.Interface;
using Model.DTO;
using Model.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class UserRepo : IUserRepo
    {
        public IDomainWritter _domainWritter;
        public IDomainReader _domainReader;
        public UserRepo(IDomainWritter domainWritter, IDomainReader domainReader)
        {
            _domainWritter = domainWritter;
            _domainReader = domainReader;
        }

        public async Task<User> AddUser(User user)
        {
            var newUser = await _domainWritter.AddAsyncGuid(user);
            await _domainWritter.SaveCoreChangesAsync();
            return newUser;
        }

        public bool IsUserEmailExisted(string email)
        {
            return _domainReader.User().Any(x => x.Email == email);
        }

        public bool IsUserPhoneNumberUsed(string phoneNumber)
        {
            return _domainReader.User().Any(x => x.PhoneNumber == phoneNumber);
        }
    }
}

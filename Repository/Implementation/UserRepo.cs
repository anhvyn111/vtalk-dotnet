using Domain.Implementation;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Model.DTO;
using Model.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public async Task<User> GetByEmail(string email)
        {
            return await _domainReader.User().Where(x => x.Email == email).FirstOrDefaultAsync();
        }

        public async Task<User> GetById(Guid id)
        {
            return await _domainReader.User().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<User> GetByPhoneNumber(string phoneNumber)
        {
            return await _domainReader.User().Where(x => x.PhoneNumber == phoneNumber).FirstOrDefaultAsync();
        }

        public Task<User> GetUserByFilter(FilterUserDto filterUserDto)
        {
            throw new NotImplementedException();
        }

        public bool IsUserEmailExisted(string email)
        {
            return _domainReader.User().Any(x => x.Email == email);
        }

        public bool IsUserPhoneNumberUsed(string phoneNumber)
        {
            return _domainReader.User().Any(x => x.PhoneNumber == phoneNumber);
        }

        public async Task<User> AddUser(User user)
        {
            var newUser = await _domainWritter.AddAsyncGuid(user);
            await _domainWritter.SaveCoreChangesAsync();
            return newUser;
        }
    }
}

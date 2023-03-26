using Model.DTO;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IUserRepo
    {
        Task<User> AddUser(User user);
        bool IsUserEmailExisted(string email);
        bool IsUserPhoneNumberUsed(string phoneNumber);
    }
}

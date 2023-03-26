using Model.Enum;
using Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    [Table("VtalkUser")]
    public class User : IEntityGuid, ICoreEntity
    {
        public virtual Guid Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime Birth { get; set; }
        [Column("Gender", TypeName = "CHAR(10)")]
        public virtual Gender Gender { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual DateTime CreatedAt { get; set; }

        public User(Guid id, string firstName, string lastName, DateTime birth, Gender gender, string phoneNumber, string email, string password)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Birth = birth;
            Gender = gender;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            CreatedAt = DateTime.UtcNow;
        }
    }
}

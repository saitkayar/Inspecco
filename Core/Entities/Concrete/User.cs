using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
       
        public byte[] PasswordSalt { get; set; }
      
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }
        public bool IsVerification { get; set; }
    }




}


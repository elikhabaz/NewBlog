using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tildaBlog.CoreLayer.Services.DTOs.Users
{
    public class UserRegisterDto
    {
        public  string Username { get; set; }
        public  string Fullname { get; set; }
        public  string Password { get; set; }

    }
}

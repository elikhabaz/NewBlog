using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tildaBlog.DataLayer.Entities;

namespace tildaBlog.CoreLayer.Services.DTOs.Users
{
    public class UserDto
    {
        public  string Username { get; set; }
        public  string Fullname { get; set; }
        public  string Password { get; set; }
        public UserRole Role { get; set; }
        public int UserId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}

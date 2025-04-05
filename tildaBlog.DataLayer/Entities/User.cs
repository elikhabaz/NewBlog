using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tildaBlog.DataLayer.Entities
{
    public class User: BaseEntity
    {
       
        public required string Username { get; set; }
        public required string Fullname { get; set; }
        public required string Password { get; set; }
        public UserRole Role { get; set; }

        public ICollection<Post> Posts { get; set; }
        public ICollection<PostComment> PostComment { get; set; }
    }
    public enum UserRole
    {
        Admin,
        User,
        Author
    }
}

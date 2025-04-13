using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tildaBlog.CoreLayer.Services.DTOs.Users;
using tildaBlog.CoreLayer.Utilities;
using tildaBlog.DataLayer.Context;
using tildaBlog.DataLayer.Entities;

namespace tildaBlog.CoreLayer.Services.Users
{
    public class UserService : IUserService
    {
        private readonly BlogContext _context;

        public UserService(BlogContext context)
        {

            _context = context;

        }
        public OperationResult RegisterUser(UserRegisterDto registerDto)
        {
            //_context.Users.Any(u=>u.Username==registerDto.Username) check if username == userexist in db you cant add the user
            var isFullNameExist = _context.Users.Any(u => u.Username == registerDto.Username);
            if (isFullNameExist)
                return OperationResult.Error("کاربر در سیستم موجود است");

            var HashPass = registerDto.Password.EncodeToMd5();
            _context.Users.Add(entity: new User()
            {
                Fullname = registerDto.Fullname,
                IsDeleted = false,
                Username = registerDto.Username,
                Role = UserRole.User,
                CreationDate = DateTime.Now,
                Password = HashPass
            });
            _context.SaveChanges();
            return OperationResult.Success("مشخصات با موفقیت درج شد");


        }
        public UserDto LoginUser(UserLoginDto loginDto) {

            var passwordHash = loginDto.Password.EncodeToMd5(); 

            var user = _context.Users.FirstOrDefault(u => u.Username == loginDto.Username && u.Password== passwordHash);
           
            if(user == null)
                return null;

            var UserDTO = new UserDto(){
                Fullname = user.Username,
                Password = user.Password,
                Username= user.Username,
                CreationDate= user.CreationDate,
                UserId=user.Id,
            };
            return UserDTO;

        }

    }
}
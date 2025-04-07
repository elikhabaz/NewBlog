using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tildaBlog.CoreLayer.Services.DTOs.Users;
using tildaBlog.CoreLayer.Utilities;

namespace tildaBlog.CoreLayer.Services.Users
{
    public interface IUserService
    {
        OperationResult RegisterUser(UserRegisterDto registerDto);

    }
}

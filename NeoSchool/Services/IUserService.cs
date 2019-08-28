using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeoSchool.Services
{
    public interface IUserService
    {
        Task<string> GetUsernameByUserId(string userId);

    }
}

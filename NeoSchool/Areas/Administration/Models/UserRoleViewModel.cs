using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeoSchool.Areas.Administration.Models
{
    public class UserRoleViewModel
    {
        public List<KeyValuePair<string, string>> UsersAndRoles { get; set; }
    }
}

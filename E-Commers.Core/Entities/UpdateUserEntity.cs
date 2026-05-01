using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commers.Core.Identity;
using Microsoft.AspNetCore.Identity;

namespace E_Commers.Core.Entities
{
    public class UpdateUserEntity
    {
        public string oldUserName { get; set; }
        public ApplicationUserIdentity ApplicationUserIdentity { get; set; }

    }
}

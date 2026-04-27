using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commers.Core.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_Commers.Infrastructure.Data
{
    public class Context: IdentityDbContext<ApplicationUserIdentity>
    {
        public Context(DbContextOptions options) : base(options)
        {

        }

    }
}

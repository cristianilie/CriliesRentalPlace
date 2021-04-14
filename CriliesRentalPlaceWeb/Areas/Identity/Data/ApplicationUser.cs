using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriliesRentalPlaceWeb.Areas.Identity.Data
{
    public class ApplicationUser : IdentityUser
    {
        public int CustomerId { get; set; }
    }
}

﻿using Microsoft.AspNetCore.Identity;

namespace DGod.SuparCar.Infrastructure.Identity.Models
{
    public class ApplicationUser : IdentityUser{
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; } = false;
    }
}


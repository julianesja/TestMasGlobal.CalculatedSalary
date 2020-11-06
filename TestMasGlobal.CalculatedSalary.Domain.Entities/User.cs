﻿
using Microsoft.AspNetCore.Identity;

namespace TestMasGlobal.CalculatedSalary.Domain.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}

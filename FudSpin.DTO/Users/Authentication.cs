﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudSpin.Dto.Users
{
    public  class Authentication
    {
        public required string? UserName { get; set; }
        public required string? Password { get; set; }
    }
}

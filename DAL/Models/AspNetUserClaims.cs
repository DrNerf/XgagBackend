﻿using System;
using System.Collections.Generic;

namespace DAL
{
    public partial class AspNetUserClaim
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public AspNetUser User { get; set; }
    }
}

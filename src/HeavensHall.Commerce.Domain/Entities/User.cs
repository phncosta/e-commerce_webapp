﻿
using System;

namespace HeavensHall.Commerce.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Is_Admin { get; set; }
    }
}

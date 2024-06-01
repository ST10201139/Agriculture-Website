﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgriConnectPlatformProject.Models
{
    public class Farmer
    {
        [Key]
        public int Id { get; set; }

       
        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }
    }
}

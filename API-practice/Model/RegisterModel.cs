﻿using System.ComponentModel.DataAnnotations;

namespace API_practice.Model
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Username is Required")] 
        public string? Username { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email is Required")]
        public string? Email{ get; set;}
        [Required(ErrorMessage = "Password is Required")]
        public string? Password { get; set; }
    }
}

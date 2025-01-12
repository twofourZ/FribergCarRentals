﻿using System.ComponentModel.DataAnnotations;

namespace FribergCarRentals.Models
{
    public class Bokning
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Startdatum saknas")]
        public DateTime Startdatum { get; set; }

        [Required(ErrorMessage = "Slutdatum saknas")]
        public DateTime Slutdatum { get; set; }

        public Kund Kund { get; set; } = null!;

        public Bil Bil { get; set; } = null!;
    }
}

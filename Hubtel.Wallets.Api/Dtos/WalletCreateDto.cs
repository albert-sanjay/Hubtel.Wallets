using Hubtel.Wallets.Api.Models;
using System.ComponentModel.DataAnnotations;
using System;

namespace Hubtel.Wallets.Api.Dtos
{
    public class WalletCreateDto
    {
        public WalletCreateDto()
        {
            CreatedAt = DateTime.UtcNow;
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public CardType Type { get; set; }

        [Required]
        public string AccountNumber { get; set; }

        [Required]
        public AccountScheme AccountScheme { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        [Phone]
        public string Owner { get; set; }


    }
}

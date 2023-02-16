using Hubtel.Wallets.Api.Models;
using System.ComponentModel.DataAnnotations;
using System;

namespace Hubtel.Wallets.Api.Dtos
{
    public class WalletReadDto
    {
        
        public int ID { get; set; }

        public string Name { get; set; }

        public CardType Type { get; set; }

        public string AccountNumber { get; set; }

        public AccountScheme AccountScheme { get; set; }

        public string CreatedAt{ get; set; } 

        public string Owner { get; set; }
    }
}

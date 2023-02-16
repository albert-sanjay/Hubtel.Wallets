using System;
using System.ComponentModel.DataAnnotations;


namespace Hubtel.Wallets.Api.Models
{
    public class WalletModel
    {
        public WalletModel()
        {
            CreatedAt = DateTime.UtcNow;
        }

        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        public CardType Type { get; set; }

        private string _accNum = "";

        [Required]
        public string AccountNumber {
            get { return _accNum; }
            set { _accNum = value.Substring(0, 6); } }

        [Required]
        public AccountScheme AccountScheme { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        [Phone]
        public string Owner { get; set; }

       

    }

    

    public enum CardType
    {
        Momo, Card
    }

    public enum AccountScheme
    {
        visa, mastercard, mtn, vodafone, airteltigo
    }


}

using Hubtel.Wallets.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hubtel.Wallets.Api.Data
{
    public class WalletRepo : IWalletRepo
    {
        private readonly WalletContext _context;

        public WalletRepo(WalletContext context)
        {
            _context = context;
        }

       
        public async Task CreateWallet(WalletModel wallet)
        {
            if (wallet == null)
            {
                throw new ArgumentNullException(nameof(wallet));
            }

            var wallets = await GetWallets();
            if (wallets.Any(w=>w.AccountNumber == wallet.AccountNumber))
            {
                throw new Exception("Wallet Duplication Not Allowed");
            }
            
            if(wallets.Count(w=>w.Owner == wallet.Owner) >= 5)
            {
                throw new Exception("A user can have a maximum of 5 wallets");
            }

            wallet.CreatedAt = DateTime.UtcNow;
            await _context.AddAsync(wallet);
            await _context.SaveChangesAsync();


        }

        public async Task DeleteWallet(WalletModel wallet)
        {
            if (wallet==null)
            {
                throw new ArgumentNullException(nameof(wallet));
            }

           _context.WalletsModel.Remove(wallet);
            await _context.SaveChangesAsync();

        }

        public  async Task<WalletModel> GetWalletByID(int Id)
        {
            return await _context.WalletsModel.SingleOrDefaultAsync(c => c.ID == Id);

        }

        public async Task<IEnumerable<WalletModel>> GetWallets()
        {
            return await _context.WalletsModel.ToListAsync();
        }

        public IEnumerable<WalletModel> GetWalletsByAccNum(string accNum)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<WalletModel> GetWalletsByOwner(string owner)
        {
            throw new System.NotImplementedException();
        }

        

        
    }
}

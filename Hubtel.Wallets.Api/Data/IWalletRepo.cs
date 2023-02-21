using Hubtel.Wallets.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hubtel.Wallets.Api.Data
{
    public interface IWalletRepo
    {
        Task<WalletModel> GetWalletByID(int Id);
        Task<IEnumerable<WalletModel>> GetWallets();
        Task CreateWallet(WalletModel wallet);
        Task DeleteWallet(WalletModel wallet);
        
    

    }
}

using CarDealership.Models.Interfaces;
using CarDealership.Models.Responses;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.BLL.Managers
{
    public class PurchaseManager
    {
        private IPurchaseRepository Repo { get; set; }

        public PurchaseManager(IPurchaseRepository purchaseRepository)
        {
            Repo = purchaseRepository;
        }

        public TResponse<Purchase> SavePurchase(Purchase purchase)
        {
            var response = new TResponse<Purchase>();

            response.Payload = Repo.SavePurchase(purchase);

            if(response.Payload != purchase)
            {
                response.Success = false;
                response.Message = $"Unsuccessfully saved purchase for Listing Id: {purchase.ListingId}";
            }
            else
            {
                response.Success = true;
            }

            return response;
        }
    }
}

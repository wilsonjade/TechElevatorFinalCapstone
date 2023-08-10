namespace Capstone.DAO
{
    using Capstone.Models;
    using System.Collections.Generic;
    public interface ISellerDao
    {
        public List<Seller> GetSellers();
        public Seller GetSellerById(int sellerId);
        public List<int> GetSellerInventoryById(int sellerId);
        public Seller CreateSeller(Seller newSeller);
        public Seller UpdateSeller(Seller sellerToUpdate);
        public bool DeleteSeller(int sellerId);
        public List<int> GetSellerByPlantId(int plantId);

    }
}

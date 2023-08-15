using Microsoft.AspNetCore.SignalR;
using System.Globalization;

namespace Capstone.Models
{
    public class Ratings
    {
        public int RatingId { get; set; }
        public int UserId { get; set; }
        public int SellerId { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }

        public string FirstName { get; set; }

        public string SellerName { get; set; }
        public Ratings() {}

        public Ratings(int ratingId, int userId, int sellerId, string title, int rating, string review, string firstName, string sellerName)
        {
            RatingId = ratingId;
            UserId = userId;
            SellerId = sellerId;
            Title = title;
            Rating = rating;
            Review = review;

            FirstName = firstName;
            SellerName = sellerName;
        }
    }
}

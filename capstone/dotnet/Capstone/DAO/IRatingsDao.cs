using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IRatingsDao 
    {
        public List<Ratings> GetRatings();
        public Ratings AddRatings(Ratings ratingToAdd);
        public bool DeleteRatings(int ratingId);
    }
}

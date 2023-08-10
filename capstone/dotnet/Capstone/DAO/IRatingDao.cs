using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IRatingDao 

    {
        public List<Ratings> GetRatings();
        public Ratings AddRatings(Ratings ratingToAdd);
        public bool DeleteRating(int ratingId);
    }
}

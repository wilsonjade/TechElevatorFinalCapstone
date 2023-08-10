using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
<<<<<<< HEAD:capstone/dotnet/Capstone/DAO/IRatingDao.cs
    public interface IRatingDao
=======
    public interface IRatingsDao 
>>>>>>> f64d789ed2d307a1fac15a5989a4d4385016ca43:capstone/dotnet/Capstone/DAO/IRatingsDao.cs
    {
        public List<Ratings> GetRatings();
        public Ratings AddRatings(Ratings ratingToAdd);
        public bool DeleteRating(int ratingId);
    }
}

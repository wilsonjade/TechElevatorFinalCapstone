using System.Collections.Generic;
using Capstone.Models;
using Microsoft.AspNetCore.SignalR;

namespace Capstone.DAO
{
    public interface IPlantDao
    {
        public List<Garden> GetAllGardens();
        List<Plant> GetPlants();

        Plant GetPlantById(int plantId);

        List<Plant> GetPlantsByUserId(int userId);

        bool AddPlantToVG(int plantId, int userId);

        bool DeletePlantFromGarden(int plantId, int userId);

        List<Plant> GetPlantsBySearchCriteria(Plant searchPlant);

    


    }
}
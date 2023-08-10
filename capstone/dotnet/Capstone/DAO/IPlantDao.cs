using System.Collections.Generic;
using Capstone.Models;
using Microsoft.AspNetCore.SignalR;

namespace Capstone.DAO
{
    public interface IPlantDao
    {
        List<Plant> GetPlants();

        Plant GetPlantById(int plantId);

        List<Plant> GetPlantsByUserId(int userId);

        bool AddPlantToVG(int plantId, int userId);

    }
}
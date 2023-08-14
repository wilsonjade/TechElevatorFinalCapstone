using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface ICommunicationDao
    {
        public List<Communication> GetCommunications();
        public List<Communication> GetCommunicationsByType(string type);
        public List<Communication> GetFutureCommunications();
        public Communication GetCommunicationById(int id);
        public Communication AddCommunication(Communication communicationToAdd);
        public Communication UpdateCommunication(Communication communicationToUpdate);
        public bool DeleteCommunication(int communicationId);
    }
}

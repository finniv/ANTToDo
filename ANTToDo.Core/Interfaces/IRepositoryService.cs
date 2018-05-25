using System.Collections.Generic;
using System.Threading.Tasks;
using ANTToDo.Core.Models;

namespace ANTToDo.Core.Interfaces
{
    public interface IRepositoryService
    {
        Task CreateActivities(Activities activities);
        Task DeleteActivities(Activities activities);
        Task<List<Activities>> GetAllActivities();
        Task UpdateActivities(Activities activities);
    }
}
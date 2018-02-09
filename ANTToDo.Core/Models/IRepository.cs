using System.Collections.Generic;
using System.Threading.Tasks;

namespace ANTToDo.Core.Models
{
    public interface IRepository
    {
        Task CreateActivities(Activities activities);
        Task DeleteActivities(Activities activities);
        Task<List<Activities>> GetAllActivities();
        Task UpdateActivities(Activities activities);
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using ANTToDo.Core.Models;

namespace ANTToDo.Core
{
    public interface IRepository
    {
        string StatusMessage { get; set; }
        Task CreateActivities(Activities activities);
        Task<List<Activities>> GetAllActivities();
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace ANTToDo.Core.Models
{
    public class Repository : IRepository
    {
        private readonly SQLiteAsyncConnection conn;

        public string StatusMessage { get; set; }

        public Repository(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<Activities>().Wait();
        }

        public async Task CreateActivities(Activities activities)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(activities.ActivitiesTitle))
                    throw new Exception("Activities Title is required");

                var result = await conn.InsertAsync(activities).ConfigureAwait(continueOnCapturedContext: false);
                StatusMessage = $"{result} record(s) added [Activities title: {activities.ActivitiesTitle})";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to create {activities.ActivitiesTitle}'s activities. Error: {ex.Message}";
            }
        }

        public async Task UpdateActivities(Activities activities)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(activities.ActivitiesTitle))
                    throw new Exception("Activities Title is required");

                var result = await conn.UpdateAsync(activities).ConfigureAwait(continueOnCapturedContext: false);
                StatusMessage = $"{result} record(s) updated [Activities title: {activities.ActivitiesTitle})";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to create {activities.ActivitiesTitle}'s activities. Error: {ex.Message}";
            }
        }
        public async Task DeleteActivities(Activities activities)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(activities.ActivitiesTitle))
                    throw new Exception("Activities Title is required");

                var result = await conn.DeleteAsync(activities).ConfigureAwait(continueOnCapturedContext: false);
                StatusMessage = $"{result} record(s) deleted [Activities title: {activities.ActivitiesTitle})";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to create {activities.ActivitiesTitle}'s activities. Error: {ex.Message}";
            }
        }


        public Task<List<Activities>> GetAllActivities()
        {
            return conn.Table<Activities>().ToListAsync();
        }
    }
}

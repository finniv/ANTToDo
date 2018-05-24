using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using ANTToDo.Core.Interfaces;
using ANTToDo.Core.Models;
using SQLite;

namespace ANTToDo.Core.Data
{
    public class RepositoryService : IRepositoryService
    {
        private readonly SQLiteAsyncConnection conn;

        public RepositoryService(string dbPath)
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

                await conn.InsertAsync(activities).ConfigureAwait(continueOnCapturedContext: false);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public async Task UpdateActivities(Activities activities)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(activities.ActivitiesTitle))
                    throw new Exception("Activities Title is required");

                await conn.UpdateAsync(activities).ConfigureAwait(continueOnCapturedContext: false);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        public async Task DeleteActivities(Activities activities)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(activities.ActivitiesTitle))
                    throw new Exception("Activities Title is required");

                await conn.DeleteAsync(activities).ConfigureAwait(continueOnCapturedContext: false);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }


        public Task<List<Activities>> GetAllActivities()
        {
            return conn.Table<Activities>().ToListAsync();
        }
    }
}
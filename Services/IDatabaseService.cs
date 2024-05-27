using GymDay.Models;

namespace GymDay.Services
{
    public interface IDatabaseService : IDisposable
    {
        void CloseConnection();
        Task<int> Count<T>() where T : BaseWorkoutComponent, new();
        Task DeleteAllAsync<T>() where T : BaseWorkoutComponent, new();
        Task<int> DeleteAsync<T>(T item) where T : BaseWorkoutComponent, new();
        Task<bool> DropAllTables();
        Task<List<T>> GetAllAsync<T>() where T : BaseWorkoutComponent, new();
        Task<List<T>> GetAllAsync<T>(int CurrentId) where T : BaseWorkoutComponent, new();
        Task<T> GetAsync<T>(int currentId) where T : BaseWorkoutComponent, new();
        Task<int> InsertAllAsync<T>(IEnumerable<T> items) where T : BaseWorkoutComponent, new();
        Task<int> InsertAsync<T>(T item) where T : BaseWorkoutComponent, new();
        Task<int> UpdateAllAsync<T>(IEnumerable<T> items) where T : BaseWorkoutComponent, new();
        Task<int> UpdateAsync<T>(T item) where T : BaseWorkoutComponent, new();
    }
}
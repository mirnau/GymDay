using GymDay.Models;
using SQLite;

namespace GymDay.Services;

public class SqLiteService : IDatabaseService
{
    private SQLiteAsyncConnection db;
    private const SQLiteOpenFlags flags =
        SQLiteOpenFlags.ReadWrite |
        SQLiteOpenFlags.Create |
        SQLiteOpenFlags.SharedCache;

    private readonly string databasePath;
    private const string foreignKeys = "PRAGMA foreign_keys = ON";
    private bool hasInstantiatedTables;

    public SqLiteService()
    {
        databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Workout.db3");
        db = new SQLiteAsyncConnection(databasePath, flags);
    }

    //For testing
    public SqLiteService(SQLiteAsyncConnection db)
    {
        this.db = db;
    }

    public async Task Init()
    {
        if (hasInstantiatedTables)
            return;

        await db.ExecuteAsync(foreignKeys);
        await db.CreateTableAsync<Routine>();
        await db.CreateTableAsync<Workout>();
        await db.CreateTableAsync<Exercise>();
        await db.CreateTableAsync<Set>();
        await db.CreateTableAsync<WorkoutPlan>();

        hasInstantiatedTables = true;
    }

    public void CloseConnection()
    {
        db.CloseAsync();
    }

    public async Task<int> InsertAsync<T>(T item) where T : BaseWorkoutComponent, new()
    {
        await Init();
        return await db.InsertAsync(item);
    }

    public async Task<int> InsertAllAsync<T>(IEnumerable<T> items) where T : BaseWorkoutComponent, new()
    {
        await Init();
        return await db.InsertAllAsync(items);
    }

    public async Task<int> UpdateAsync<T>(T item) where T : BaseWorkoutComponent, new()
    {
        await Init();
        return await db.UpdateAsync(item);
    }

    public async Task<int> UpdateAllAsync<T>(IEnumerable<T> items) where T : BaseWorkoutComponent, new()
    {
        await Init();
        return await db.UpdateAllAsync(items);
    }

    public async Task<int> DeleteAsync<T>(T item) where T : BaseWorkoutComponent, new()
    {
        await Init();
        return await db.DeleteAsync(item);
    }

    public async Task<List<T>> GetAllAsync<T>() where T : BaseWorkoutComponent, new()
    {
        await Init();
        return await db.Table<T>().ToListAsync();
    }

    public async Task<T> GetALLAsync<T>(int currentId) where T : BaseWorkoutComponent, new()
    {
        await Init();
        return await db.Table<T>().Where(item => item.Id == currentId).FirstOrDefaultAsync();
    }

    //Debug
    public async Task<int> Count<T>() where T : BaseWorkoutComponent, new()
    {
        await Init();
        return await db.Table<T>().CountAsync();
    }

    public async Task DeleteAllAsync<T>() where T : BaseWorkoutComponent, new()
    {
        await Init();
        await db.DeleteAllAsync<T>();
    }

    public async Task<bool> DropAllTables()
    {
        await Init();

        await db.DeleteAllAsync<WorkoutPlan>();
        int workoutPlans = await db.DropTableAsync<WorkoutPlan>();
        if (workoutPlans > 0) { return false; }

        await db.DeleteAllAsync<Routine>();
        int routines = await db.DropTableAsync<Routine>();
        if (routines > 0) { return false; }

        await db.DeleteAllAsync<Workout>();
        int workouts = await db.DropTableAsync<Workout>();
        if (workouts > 0) { return false; }

        await db.DeleteAllAsync<Exercise>();
        int exercises = await db.DropTableAsync<Exercise>();
        if (exercises > 0) { return false; }

        await db.DeleteAllAsync<Set>();
        int sets = await db.DropTableAsync<Set>();
        if (sets > 0) { return false; }

        return true;
    }

    public void Dispose()
    {
        if (db != null)
        {
            db.CloseAsync().Wait();
            db = null;
        }
    }

    public async Task<List<T>> GetAllAsync<T>(int rank) where T : BaseWorkoutComponent, new()
    {
        await Init();
        return await db.Table<T>().Where(item => item.Id == rank).ToListAsync();
    }

    public async Task<T> GetAsync<T>(int rank) where T : BaseWorkoutComponent, new()
    {
        await Init();
        return await db.Table<T>().Where(item => item.Id == rank).FirstOrDefaultAsync();
    }

    public async Task<List<T>> GetAllByParentId<T>(int CurrentId) where T : BaseWorkoutComponent, IModelWithParentId, new()
    {
        await Init();
        return await db.Table<T>().Where(item => item.ParentId == CurrentId).ToListAsync();
    }

    public async Task<T> GetByParentIdAsync<T>(int currentId) where T : BaseWorkoutComponent, IModelWithParentId, new()
    {
        await Init();
        return await db.Table<T>().Where(item => item.ParentId == currentId).FirstOrDefaultAsync();
    }
}
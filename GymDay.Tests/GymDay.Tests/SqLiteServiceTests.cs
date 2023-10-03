using GymDay.Models;
using GymDay.Services;
using SQLite;

public class SqLiteServiceTests
{
    // Define a property to hold the IDatabaseService
    private static IDatabaseService GetDbService() => new SqLiteService(
        new SQLiteAsyncConnection(":memory:", SQLiteOpenFlags.ReadWrite |
            SQLiteOpenFlags.Create |
            SQLiteOpenFlags.SharedCache));

    [Fact]
    public async Task TestForSizeZero()
    {
        // Arrange
        using var dbService = GetDbService();
        // Act
        int count = await dbService.Count<WorkoutPlan>();

            // Assert
            Assert.Equal(0, count);
    }

    [Fact]
    public async Task AddOneObject()
    {
        // Arrange
        using var dbService = GetDbService();
        List<WorkoutPlan> plans = new();
        WorkoutPlan workoutPlan = new WorkoutPlan();

        // Act
        await dbService.InsertAsync(workoutPlan);
        plans.Clear();
        plans = await dbService.GetAll<WorkoutPlan>();

        // Assert
        Assert.Single(plans);
    }

    [Fact]
    public async Task AddManyObjects()
    {
        // Arrange
        using var dbService = GetDbService();
        List<WorkoutPlan> plans = new();

        // Act
        for (int i = 0; i < 5; i++)
        {
            WorkoutPlan workoutPlan = new() { Rank = i + 1 };
            await dbService.InsertAsync(workoutPlan);
        }
        plans.Clear();
        plans = await dbService.GetAll<WorkoutPlan>();

        // Assert
        Assert.Equal(5, plans.Count());
        Assert.Equal(1, plans[0].Rank);
    }

    [Fact]
    public async Task ForeignKeysAreAutoInitialized()
    {
        // Arrange
        using var dbService = GetDbService();
        WorkoutPlan plan;
        WorkoutPlan planFromDatabase;
        Routine routine;
        List<WorkoutPlan> list;

        // Act
        plan = new WorkoutPlan();
        await dbService.InsertAsync(plan);
        routine = new Routine { WorkoutPlanId = 1 };
        await dbService.InsertAsync(routine);
        list = await dbService.GetAll<WorkoutPlan>();
        planFromDatabase = list[0];

        // Assert
        Assert.NotNull(planFromDatabase);
        Assert.Null(planFromDatabase.Routines);
    }

    [Fact]
    public async Task TestWorkoutForSizeZero()
    {
        // Arrange
        using var dbService = GetDbService();
        int count;
        int itemsInList;
        
        // Act
        
        count = await dbService.Count<Workout>();
        List<Workout> workouts = await dbService.GetAll<Workout>();
        itemsInList = workouts.Count();

        // Assert
        Assert.Equal(0, count);
        Assert.Equal(0, itemsInList);
    }

    [Fact]
    public async Task TestRoutinesForSizeZero()
    {
        // Arrange
        using var dbService = GetDbService();
        int count;
        int itemsInList;

        // Act
        count = await dbService.Count<Routine>();
        List<Routine> routines = await dbService.GetAll<Routine>();
        itemsInList = routines.Count();

        // Assert
        Assert.Equal(0, count);
        Assert.Equal(0, itemsInList);
    }

    [Fact]
    public async Task TestExerciseForSizeZero()
    {
        // Arrange
        using var dbService = GetDbService();
        int count;
        int itemsInList;

        // Act
        count = await dbService.Count<Exercise>();
        List<Exercise> exercises = await dbService.GetAll<Exercise>();
        itemsInList = exercises.Count();

        // Assert
        Assert.Equal(0, count);
        Assert.Equal(0, itemsInList);
    }

    [Fact]
    public async Task TestSetForSizeZero()
    {
        // Arrange
        using var dbService = GetDbService();
        int count;
        int itemsInList;

        // Act
        count = await dbService.Count<Set>();
        List<Set> sets = await dbService.GetAll<Set>();
        itemsInList = sets.Count();

        // Assert
        Assert.Equal(0, count);
        Assert.Equal(0, itemsInList);
    }
}
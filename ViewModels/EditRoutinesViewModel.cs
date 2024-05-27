using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GymDay.Models;
using GymDay.Services;
using System.Collections.ObjectModel;

namespace GymDay.ViewModels;

[QueryProperty(nameof(Rank), "rank")]
public partial class EditRoutinesViewModel : BaseViewModel
{
    [ObservableProperty]
    private WorkoutProgram workoutProgram;

    [ObservableProperty]
    private ObservableCollection<Workout> observableRoutines;

    private int rank;
    private readonly IDatabaseService dbService;

    public EditRoutinesViewModel(IDatabaseService dbService)
    {
        this.dbService = dbService;
        ObservableRoutines = [];
    }

    private async Task InitAsync()
    {
        WorkoutProgram = await dbService.GetAsync<WorkoutProgram>(Rank);
        WorkoutProgram.LastView = DateTime.Now;

        List<Workout> routinesList = await dbService.GetAllByParentId<Workout>(WorkoutProgram.Id);
        ObservableRoutines = new ObservableCollection<Workout>(routinesList);

        if (ObservableRoutines.Any())
        {
            _ = ObservableRoutines.OrderBy(item => item.Rank);
        }
    }

    [RelayCommand]
    private async Task AddRoutineAsync()
    {
        Workout workout = new()
        {
            TimeCreated = DateTime.Now,
            LastView = DateTime.Now,
            ParentId = Rank,
            Rank = ObservableRoutines.Count + 1
        };

        await dbService.InsertAsync(workout);

        ObservableRoutines.Add(workout);
    }

    [RelayCommand]
    public void Reorder()
    {
        // Implement the logic for reordering routines
    }

    public int Rank
    {
        get => rank;
        set
        {
            SetProperty(ref rank, value);
            _ = InitAsync();
        }
    }
}
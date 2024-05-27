using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GymDay.Models;
using GymDay.Services;
using System.Collections.ObjectModel;

namespace GymDay.ViewModels
{
    [QueryProperty(nameof(CurrentId), "currentId")]
    public partial class EditRoutinesViewModel : BaseViewModel
    {
        [ObservableProperty]
        private WorkoutPlan workoutProgram;

        [ObservableProperty]
        private ObservableCollection<Routine> routines;

        private int currentId;
        private readonly IDatabaseService dbService;

        public EditRoutinesViewModel(IDatabaseService dbService)
        {
            this.dbService = dbService;
            Routines = new ObservableCollection<Routine>();
        }

        private async Task InitAsync()
        {
            WorkoutProgram = await dbService.GetAsync<WorkoutPlan>(CurrentId);
            WorkoutProgram.LastView = DateTime.Now;

            List<Routine> routinesList = await dbService.GetAllAsync<Routine>(CurrentId);
            Routines = new ObservableCollection<Routine>(routinesList);

            // Add any additional initialization logic here, e.g., calculating Ranks
            // if (routinesList.Any())
            // {
            //     // Implement logic to set up Routines collection properly
            // }
        }

        [RelayCommand]
        private async Task AddRoutineAsync()
        {
            Routine routine = new()
            {
                Rank = Routines.Count + 1
            };

            await dbService.InsertAsync(routine);

            Routines.Add(routine);
        }

        [RelayCommand]
        public void Reorder()
        {
            // Implement the logic for reordering routines
        }

        public int CurrentId
        {
            get => currentId;
            set
            {
                SetProperty(ref currentId, value);
                _ = InitAsync(); // Call the async initialization method
            }
        }
    }
}

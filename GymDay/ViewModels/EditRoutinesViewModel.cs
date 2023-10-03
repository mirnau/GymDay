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

        [ObservableProperty] WorkoutPlan workoutProgram;
        [ObservableProperty] ObservableCollection<Routine> routines;

        private int currentId;
        private readonly IDatabaseService dbService;

        public EditRoutinesViewModel(IDatabaseService dbService)
        {
            this.dbService = dbService;
            Routines = new();
            Init();
        }

        private async void Init()
        {
            WorkoutProgram = await dbService.GetAsync<WorkoutPlan>(CurrentId);
            WorkoutProgram.LastView = DateTime.Now;

//            Routines = dbService.GetAll

        //    //if (!routines.Any())
        //    //    return;

        //    //int iterations = routines.DistinctBy(routine => routine.Rank).Count();

        //    //for (int i = 0; i < iterations; i++)
        //    //{
        //    //    Routines.Add(new()
        //    //    {
        //    //        Rank = i + 1,
        //    //        Workouts = new(routines.Where(w => w. == i).ToList())
        //    //    });
        //    //}
        }

        [RelayCommand]
        private void AddRoutine()
        {
            Routine routine = new();

            dbService.InsertAsync(routine);

            Routines.Add(routine);
            Routines.Last().Rank = Routines.IndexOf(routine);
        }

        [RelayCommand]
        public void Reorder()
        { 
            
        }

        public int CurrentId
        {
            get => currentId;
            set
            {
                SetProperty(ref currentId, value);
                Init();
            }
        }
    }
}
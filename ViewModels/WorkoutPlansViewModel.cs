using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GymDay.Models;
using GymDay.Services;
using GymDay.Views;
using GymDay.Views.Popups;
using System.Collections.ObjectModel;

namespace GymDay.ViewModels
{
    public partial class WorkoutPlansViewModel : BaseViewModel
    {
        private IDatabaseService dbService;

        [ObservableProperty] ObservableCollection<WorkoutPlan> programs;
        [ObservableProperty] string emptyCollectionMessage = "No Workouts Created";
        [ObservableProperty] int cornerRadius;

        public WorkoutPlansViewModel(IDatabaseService dbService)
        {
            this.Title = "Manage Programs";
            this.dbService = dbService;

            Programs = new();

            Init();
        }

        private async void Init()
        {
            List<WorkoutPlan> collection = await dbService.GetAllAsync<WorkoutPlan>();

            if (collection.Count > 0)
            {
                Programs = new(collection.OrderBy(p => p.Rank));
            }
        }

        [RelayCommand]
        private async Task Reorder()
        {
            for (int i = 0; i < Programs.Count; i++)
            {
                Programs[i].Rank = i;
            }

            await dbService.UpdateAllAsync(Programs);
        }

        [RelayCommand]
        private async Task NavigateToRoutines(WorkoutPlan workoutProgram)
        {
            await Shell.Current.GoToAsync($"{nameof(EditRoutinesPage)}?rank={workoutProgram.Id}");
        }

        [RelayCommand]
        public async Task AddWorkoutProgram()
        {
            string name = await ShowPopupDialogSetName();

            if (name == null || name == string.Empty)
                return;

            WorkoutPlan workoutProgram = new()
            {
                Name = name,
                TimeCreated = DateTime.Now,
            };

            Programs.Add(workoutProgram);
            workoutProgram.Rank = Programs.IndexOf(workoutProgram);

            await dbService.InsertAsync(workoutProgram);
            Programs = new(await dbService.GetAllAsync<WorkoutPlan>());
        }

        [RelayCommand]
        public async Task ShowDeleteWarning(WorkoutPlan workoutProgram)
        {
            DeleteDialoguePage popup = new()
            {
                CanBeDismissedByTappingOutsideOfPopup = true
            };

            bool deleteIsPermitted = (bool)(await Application.Current.MainPage.ShowPopupAsync(popup));

            if (deleteIsPermitted && workoutProgram != null)
            {
                await dbService.DeleteAsync(workoutProgram);
                Programs.Remove(workoutProgram);
            }
        }

        [RelayCommand]
        public async Task Edit(WorkoutPlan plan)
        {
            string name = await ShowPopupDialogSetName();

            if (name == null || name == string.Empty)
                return;

            plan.Name = name;

            Programs = new(Programs);

            await dbService.UpdateAsync(plan);
        }

        public async Task<string> ShowPopupDialogSetName()
        {
            ReturnNameDialoguePage popup = new()
            {
                CanBeDismissedByTappingOutsideOfPopup = false
            };

            return (string)(await Application.Current.MainPage.ShowPopupAsync(popup));
        }
    }
}
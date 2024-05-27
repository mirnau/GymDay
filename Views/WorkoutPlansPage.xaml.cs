using GymDay.ViewModels;

namespace GymDay.Views;

public partial class WorkoutProgramsPage : ContentPage
{
	public WorkoutProgramsPage(WorkoutProgramsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
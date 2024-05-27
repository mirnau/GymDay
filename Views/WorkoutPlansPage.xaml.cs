using GymDay.ViewModels;

namespace GymDay.Views;

public partial class WorkoutPlansPage : ContentPage
{
	public WorkoutPlansPage(WorkoutPlansViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
using GymDay.ViewModels;

namespace GymDay.Views;

public partial class CurrentWorkoutPage : ContentPage
{
	public CurrentWorkoutPage(CurrentWorkoutViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
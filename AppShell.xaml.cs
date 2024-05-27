using GymDay.Views;

namespace GymDay;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(WelcomePage), typeof(WelcomePage));
		Routing.RegisterRoute(nameof(CurrentWorkoutPage), typeof(CurrentWorkoutPage));
		Routing.RegisterRoute(nameof(WorkoutProgramsPage), typeof(WorkoutProgramsPage));
		Routing.RegisterRoute(nameof(EditRoutinesPage), typeof(EditRoutinesPage));
	}
}

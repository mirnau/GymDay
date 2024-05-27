using GymDay.ViewModels;

namespace GymDay.Views;

public partial class WelcomePage : ContentPage
{
	public WelcomePage(WelcomeViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
using GymDay.ViewModels;

namespace GymDay.Views;

public partial class EditRoutinesPage : ContentPage
{
    public EditRoutinesPage(EditRoutinesViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
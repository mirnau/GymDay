using CommunityToolkit.Mvvm.ComponentModel;

namespace GymDay.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty] bool isBusy;
    [ObservableProperty] string title;
}

using CommunityToolkit.Maui.Views;
namespace GymDay.Views.Popups;

public partial class ReturnNameDialoguePage : Popup
{
    public ReturnNameDialoguePage()
    {
        InitializeComponent();
    }

    public void Ok_Button_Clicked(object sender, EventArgs e) => Close(EntryField.Text);
    public void Cancel_Button_Clicked(object sender, EventArgs e) => Close(string.Empty);
}
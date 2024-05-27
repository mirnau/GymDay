using CommunityToolkit.Maui.Views;
namespace GymDay.Views.Popups;

public partial class DeleteDialoguePage : Popup
{
	public DeleteDialoguePage()
	{
		InitializeComponent();
	}

    public void Yes_Button_Clicked(object sender, EventArgs e) => Close(true);

    public void No_Button_Clicked(object sender, EventArgs e) => Close(false);
}
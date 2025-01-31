using TaskerApp.MVVM.ViewModels;

namespace TaskerApp.MVVM.Views;

public partial class MainView : ContentPage
{
	
	private MainViewModel mainViewModel = new MainViewModel();
    public MainView()
	{
		InitializeComponent();
		BindingContext = mainViewModel;
	}

    private void checkBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
		mainViewModel.UpdateData();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var taskView = new NewTaskView()
        {
            BindingContext = new NewTaskViewModel()
            {
                Categories = mainViewModel.Categories,
                Tasks = mainViewModel.Tasks
            }
        };
        Navigation.PushAsync(taskView);
    }
}
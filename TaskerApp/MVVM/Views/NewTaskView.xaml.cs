using TaskerApp.MVVM.Models;
using TaskerApp.MVVM.ViewModels;

namespace TaskerApp.MVVM.Views;

public partial class NewTaskView : ContentPage
{
	public NewTaskView()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		var ViewModel = BindingContext as NewTaskViewModel;
		var selectedCategory = ViewModel.Categories.Where(vm => vm.IsSelected).FirstOrDefault();
        if (selectedCategory != null)
        {
            var task = new MyTask
            {
                Completed = false,
                TaskName = ViewModel.Task,
                TaskColor = selectedCategory.Color,
                CategoryId = selectedCategory.Id
            };
            ViewModel.Tasks.Add(task);
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Error", "Please select a category", "Ok");
        }
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        var ViewModel = BindingContext as NewTaskViewModel;
        string category = await DisplayPromptAsync("New Category", "Enter the name of the new category",maxLength:15,keyboard:Keyboard.Text);
        var r = new Random();
        if (!string.IsNullOrEmpty(category))
        {
            var newCategory = new Category
            {
                Id = r.Next(1000),
                CategoryName = category,
                Color = $"#{r.Next(0x1000000):X6}"
            };
            ViewModel.Categories.Add(newCategory);
            Navigation.PopAsync();
        }
    }
}
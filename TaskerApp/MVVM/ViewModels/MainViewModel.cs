using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskerApp.MVVM.Models;

namespace TaskerApp.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainViewModel
    {
        public ObservableCollection<Category>? Categories { get; set; }
        public ObservableCollection<MyTask>? Tasks { get; set; }
        public MainViewModel()
        {
            FillData();
            Tasks.CollectionChanged += Task_CollectionChanged;
        }

        private void Task_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void FillData()
        {
            Categories = new ObservableCollection<Category>()
            {
                new Category
                {
                    Id = 1,
                    CategoryName = ".Net Maui Course",
                    Color = "#125733",
                },
                new Category
                {
                    Id = 2,
                    CategoryName = "Tutorials",
                    Color = "#558933",
                },
                new Category
                {
                    Id = 3,
                    CategoryName = "Shopping",
                    Color = "#971233",
                },
                new Category
                {
                    Id = 4,
                    CategoryName = "Personal",
                    Color = "#F25733",
                },
            };
            Tasks = new ObservableCollection<MyTask>()
            {
                new MyTask
                {
                    TaskName = "Create .Net Maui Course",
                    Completed = true,
                    CategoryId = 1,
                    TaskColor = "#BB5733",
                },
                new MyTask
                {
                    TaskName = "Create .Net Maui Course",
                    Completed = false,
                    CategoryId = 4,
                    TaskColor = "#BB5733",
                },
                new MyTask
                {
                    TaskName = "Create .Net Maui Course",
                    Completed = false,
                    CategoryId = 3,
                    TaskColor = "#BB5733",
                },
                new MyTask
                {
                    TaskName = "Create .Net Maui Course",
                    Completed = true,
                    CategoryId = 3,
                    TaskColor = "#BB5733",
                },
                new MyTask
                {
                    TaskName = "Create .Net Maui Course",
                    Completed = true,
                    CategoryId = 4,
                    TaskColor = "#BB5733",
                },
                new MyTask
                {
                    TaskName = "Create .Net Maui Course",
                    Completed = true,
                    CategoryId = 2,
                    TaskColor = "#BB5733",
                },
                new MyTask
                {
                    TaskName = "Create .Net Maui Course",
                    Completed = false,
                    CategoryId = 2,
                    TaskColor = "#BB5733",
                }
            };
            UpdateData();
        }
        public void UpdateData()
        {
            if (Categories != null && Categories.Count >= 0 && Tasks != null && Tasks.Count >= 0)
            {
                foreach (var item in Categories)
                {
                    var tasks = Tasks.Where(task => task.CategoryId == item.Id).ToList();
                    var completed = tasks.Where(task => task.Completed == true).ToList();
                    var notCompleted = tasks.Where(task => task.Completed == false).ToList();
                    item.PendingTasks = notCompleted.Count();
                    item.Percentage = completed.Count == 0 || tasks.Count==0 ? 0 : (float)((float)completed.Count()/ (float)tasks.Count());
                }
                foreach (var task in Tasks)
                {
                    var catColor = (from c in Categories where c.Id == task.CategoryId select c.Color).FirstOrDefault();
                    task.TaskColor = catColor;
                }
            }
        }
    }
    
}

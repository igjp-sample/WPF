using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMGridDiagram.Models;
using Task = VMGridDiagram.Models.Task;

namespace VMGridDiagram.ViewModels
{
    public class TaskViewModel
    {
        public ObservableCollection<Task> Tasks { get; set; } = new ObservableCollection<Task>();

        public TaskViewModel()
        {
            Task task1 = new Task { Id = "1", Name = "Task 1", StartTaskId = "1", EndTaskId = "2", Done = true };
            Task task2 = new Task { Id = "2", Name = "Task 2", StartTaskId = "2", EndTaskId = "3", Done = false };
            Task task3 = new Task { Id = "3", Name = "Task 3", Done = false };

            this.Tasks.Add(task1);
            this.Tasks.Add(task2);
            this.Tasks.Add(task3);


        }
    }
}

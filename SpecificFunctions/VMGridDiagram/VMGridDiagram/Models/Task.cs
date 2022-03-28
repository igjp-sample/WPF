using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace VMGridDiagram.Models
{
    public class Task : INotifyPropertyChanged
    {

        private static int MaxId = 0;

        public Task()
        {
            MaxId++;
            this.Id = MaxId.ToString();
        }

        private string _id;
        public string Id
        {
            get { return _id; }
            set
            {
                int id = int.Parse(value);
                if (id > MaxId)
                {
                    MaxId = id;
                }
                _id = value; OnPropertyChanged();
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }

        private bool _done;
        public bool Done
        {
            get { return _done; }
            set { _done = value; OnPropertyChanged(); }
        }

        private string _startTaskId;
        public string StartTaskId
        {
            get { return _startTaskId; }
            set { _startTaskId = value; OnPropertyChanged(); }
        }

        private string _endTaskId;
        public string EndTaskId
        {
            get { return _endTaskId; }
            set { _endTaskId = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

using C_00223816_SampleApp1.Infrastructure;
using C_00223816_SampleApp1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_00223816_SampleApp1
{
    internal class MainWindowViewModel : ObservableObject
    {
        private ObservableCollection<Person> _people;

        public ObservableCollection<Person> People
        {
            get { return _people; }
            set { _people = value; OnPropertyChanged(); }
        }

        public MainWindowViewModel()
        {
            _people = new ObservableCollection<Person>();
            _people.Add(new Person() { ID = 1, FamilyName = "相田", GivenName = "早希", ZipCode = "982-0815", Prefecture = "宮城県" });
            _people.Add(new Person() { ID = 2, FamilyName = "冨田", GivenName = "結衣", ZipCode = "635-0041", Prefecture = "奈良県" });
            _people.Add(new Person() { ID = 3, FamilyName = "高山", GivenName = "御喜家", ZipCode = "894-1508", Prefecture = "鹿児島県" });
            _people.Add(new Person() { ID = 4, FamilyName = "溝口", GivenName = "萌", ZipCode = "692-0066", Prefecture = "島根県" });
            _people.Add(new Person() { ID = 5, FamilyName = "高井", GivenName = "智博", ZipCode = "185-0024", Prefecture = "東京都" });
        }
    }
}

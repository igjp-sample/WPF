using C_00223816_SampleApp1.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_00223816_SampleApp1.Model
{
    internal class Person : ObservableObject
    {
        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(); }
        }

        private String _familyName;

        public String FamilyName
        {
            get { return _familyName; }
            set { _familyName = value; OnPropertyChanged(); }
        }

        private String _givenName;

        public String GivenName
        {
            get { return _givenName; }
            set { _givenName = value; OnPropertyChanged(); }
        }

        private String _zipCode;

        public String ZipCode
        {
            get { return _zipCode; }
            set { _zipCode = value; OnPropertyChanged(); }
        }

        private String _prefecture;

        public String Prefecture
        {
            get { return _prefecture; }
            set { _prefecture = value; OnPropertyChanged(); }
        }

        public Person()
        {

        }
    }
}

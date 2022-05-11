using Infragistics.Controls.Charts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace XamDataChart_ScatterLine
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }
    }

    public class BubbleDataSource : List<ChartData>
    {
        public BubbleDataSource()
        {
            this.Add(new ChartData() { Label = "1", Value = 1, YValue = 7.0, XValue = 0 });
            this.Add(new ChartData() { Label = "2", Value = 2, YValue = 8.0, XValue = 1.0 });
            this.Add(new ChartData() { Label = "3", Value = 3, YValue = 7.0, XValue = 2.0 });
            this.Add(new ChartData() { Label = "4", Value = 4, YValue = 7.0, XValue = 3.0 });
            this.Add(new ChartData() { Label = "5", Value = 5, YValue = 7.2, XValue = 4.0 });
            this.Add(new ChartData() { Label = "6", Value = 6, YValue = 7.3, XValue = 5.0 });
            this.Add(new ChartData() { Label = "7", Value = 7, YValue = 7.4, XValue = 6.0 });
            this.Add(new ChartData() { Label = "8", Value = 8, YValue = 7.5, XValue = 7.0 });
            this.Add(new ChartData() { Label = "9", Value = 9, YValue = 7.6, XValue = 8.0 });
        }
    }

    public partial class MainWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ChartData> _chartDataSource;

        public ObservableCollection<ChartData> ChartDataSource
        {
            get
            {
                return _chartDataSource;
            }
            set
            {
                if (_chartDataSource == value)
                    return;
                _chartDataSource = value;
                RaisePropertyChanged("ChartDataSource");
            }
        }

        public MainWindowViewModel()
        {
            ChartDataSource = new ObservableCollection<ChartData>();


            ChartDataSource.Add(new ChartData() { Label = "1", Value = 1, YValue = 7.0, XValue = 0 });
            ChartDataSource.Add(new ChartData() { Label = "2", Value = 2, YValue = 8.0, XValue = 1.0 });
            ChartDataSource.Add(new ChartData() { Label = "3", Value = 3, YValue = 7.0, XValue = 2.0 });
            ChartDataSource.Add(new ChartData() { Label = "4", Value = 4, YValue = 7.0, XValue = 3.0 });
            ChartDataSource.Add(new ChartData() { Label = "5", Value = 5, YValue = 7.2, XValue = 4.0 });
            ChartDataSource.Add(new ChartData() { Label = "6", Value = 6, YValue = 7.3, XValue = 5.0 });
            ChartDataSource.Add(new ChartData() { Label = "7", Value = 7, YValue = 7.4, XValue = 6.0 });
            ChartDataSource.Add(new ChartData() { Label = "8", Value = 8, YValue = 7.5, XValue = 7.0 });
            ChartDataSource.Add(new ChartData() { Label = "9", Value = 9, YValue = 7.6, XValue = 8.0 });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }

    public class ChartData
    {
        public string Label { get; set; }
        public double Value { get; set; }
        public double YValue { get; set; }
        public double XValue { get; set; }
    }
}

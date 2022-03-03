using Infragistics.Controls.Schedules;
using Infragistics.Controls.Schedules.Primitives;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sample
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.xamGantt.Project = CreateProject();
            this.xamGantt.TaskBarDragCompleted += XamGantt_TaskBarDragCompleted;
        }

        private void XamGantt_TaskBarDragCompleted(object sender, GanttTaskBarDragCompletedEventArgs e)
        {
            Debug.WriteLine("ManualStart:" + e.Task.ManualStart.Value.Value);
            Debug.WriteLine("ManualFinish:" + e.Task.ManualFinish.Value.Value);
            Debug.WriteLine("ManualDuration:" + e.Task.ManualDuration.Value.Value.Duration);
            Debug.WriteLine("");


            DateTime startBase = e.Task.ManualStart.Value.Value;
            DateTime finishBase = e.Task.ManualFinish.Value.Value;

            TimeSpan ts = finishBase - startBase;


            // 15分単位の調整
            // 1日の作業量に調整
            double durationMinutes = ts.TotalMinutes - (ts.TotalMinutes % 15);


            // 開始時間の補正
            int startMinutes = startBase.Minute - (startBase.Minute % 15);
            DateTime dstart = new DateTime(startBase.Year, startBase.Month, startBase.Day, startBase.Hour, startMinutes, 0);

            e.Task.ManualStart = new ManualDateTime(dstart);
            e.Task.ManualDuration = ProjectDuration.FromFormatUnits(durationMinutes, ProjectDurationFormat.Minutes);


        }

        private Project CreateProject()
        {
            Project project = new Project();

            var dfStr = project.SettingsResolved.DefaultStartTime;
            var dff = project.SettingsResolved.DefaultFinishTime;

            // デフォルトの開始、終了日付を設定
            project.SettingsResolved.DefaultStartTime = TimeSpan.FromHours(8);
            project.SettingsResolved.DefaultFinishTime = TimeSpan.FromHours(17);

            // Dates are saved in UTC in xamGantt
            DateTime startTime = DateTime.Today;

            ProjectTask rootTask = project.RootTask;
            rootTask.TaskName = "root";


            // Add tasks to the root task
            rootTask.Tasks.Add(new ProjectTask
            {
                TaskName = "task1",
                IsManual = true,
                Start = startTime,
                ManualDuration = ProjectDuration.FromFormatUnits(30, ProjectDurationFormat.Minutes)
            });

            return project;
        } 
    }
}

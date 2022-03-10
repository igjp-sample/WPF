using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sample.Models
{
    /// <summary>
    /// XamDiagram 上に表示される矩形
    /// </summary>
    public class Node : INotifyPropertyChanged
    {
        /// <summary>
        /// 矩形(ノード)上に表示されるテキスト
        /// </summary>
        private string _Title;
        public string Title
        {
            get { return _Title; }
            set { _Title = value; OnPropertyChanged(); }
        }

        private Point _MyPosition;
        public Point MyPosition
        {
            get { return _MyPosition; }
            set { _MyPosition = value; OnPropertyChanged(); }
        }

        private NodeType _NodeType;
        public NodeType NodeType
        {
            get { return _NodeType; }
            set { _NodeType = value; OnPropertyChanged(); }
        }


        /// <summary>
        /// プロパティ値の変更をクライアントに通知する。
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// PropertyChanged イベント を発生させる。
        /// </summary>
        /// <param name="propertyName">変更されたプロパティ名</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}

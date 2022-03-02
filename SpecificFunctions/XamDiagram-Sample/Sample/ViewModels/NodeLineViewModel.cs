using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Models;

namespace Sample.ViewModels
{
    public class NodeLineViewModel
    {
        public ObservableCollection<Node> Nodes { get; set; } = new ObservableCollection<Node>();
        public ObservableCollection<Line> Lines { get; set; } = new ObservableCollection<Line>();

        public NodeLineViewModel()
        {
            Node node1 = new Node { Title = "Node 1" };
            Node node2 = new Node { Title = "Node 2" };
            Node node3 = new Node { Title = "Node 3" };

            this.Nodes.Add(node1);
            this.Nodes.Add(node2);
            this.Nodes.Add(node3);

            Line line1 = new Line { StartNode = node1, EndNode = node2 };
            Line line2 = new Line { StartNode = node2, EndNode = node3 };

            this.Lines.Add(line1);
            this.Lines.Add(line2);
        }
    }
}

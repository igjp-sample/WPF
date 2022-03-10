using Infragistics.Controls.Charts;
using Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sample
{
    public class CustomDiagonalLayout : IDiagramLayout
    {
        public int StartOffset { get; set; } = 40;

        public int ColumnWidth { get; set; } = 160;

        public int MaxRows { get; set; } = 4;

        public int MaxColumns { get; set; } = 3;


        public double Offset { get; set; }

        public CustomDiagonalLayout()
        {
        }

        public void ArrangeNodes(IEnumerable<DiagramNode> nodes)
        {
            if(nodes.Count() <= 0)
            {
                return;
            }

            XamDiagram diagram = nodes.ToArray()[0].Diagram;


            double rowHeight = diagram.ActualHeight / MaxRows;
            double columnWidth = diagram.ActualWidth / MaxColumns;


            Point nextPoint = new Point(0, 0);

            // 各行の色付
            NodeType[] types = new NodeType[] { NodeType.CUSTOMER, NodeType.SALES, NodeType.MANAGEMENT, NodeType.CREDIT_DEPARTMENT };


            for(int r=1; r<=MaxRows; r++)
            {
                double fromHeight = rowHeight * (r - 1);
                double toHeight = rowHeight * r;

                var filterNodes = nodes.Where(d =>
                    fromHeight <= d.Position.Y
                    && d.Position.Y <= toHeight).ToArray();



                foreach (var node in filterNodes)
                {
                    double centerHeight = rowHeight / 2;
                    double nodeCenterHeight = node.ActualHeight / 2;
                    double y = toHeight - centerHeight - nodeCenterHeight;


                    int nodeWidth = (int)(node.Position.X / ColumnWidth);
                    double x = nodeWidth * ColumnWidth + StartOffset;

                    Node nodeVM = node.Content as Node;
                    nodeVM.NodeType = types[r - 1];

                    nextPoint = new Point(x, y);
                    node.Position = nextPoint;
                }
            }

        }
    }

}

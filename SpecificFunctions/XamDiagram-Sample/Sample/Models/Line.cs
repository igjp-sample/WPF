using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Models
{
    /// <summary>
    /// XamDiagram ノード間をつなぐ線
    /// </summary>
    public class Line
    {
        /// <summary>
        /// 始点となるノード
        /// </summary>
        public Node StartNode { get; set; }
        
        /// <summary>
        /// 終点となるノード
        /// </summary>
        public Node EndNode { get; set; }

        /// <summary>
        /// 線上に表示されるテキストを消す
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Empty;
        }
    }
}

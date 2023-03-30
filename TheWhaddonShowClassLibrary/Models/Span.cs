using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWhaddonShowClassLibrary.Models
{
    /// <summary>
    /// A span of different TextType within a parent script item.
    /// </summary>
    public class Span
    {
        /// <summary>
        /// The start position of the span within its parent script item.
        /// </summary>
        public int StartPosition { get; set; }
        /// <summary>
        /// The end position of the span within its parent script item.
        /// </summary>
        public int EndPosition { get; set; }
        /// <summary>
        /// The Text Type for the span (that will override any other Text Type set.)
        /// </summary>
        TextType? TextType { get; set; }
    }
}

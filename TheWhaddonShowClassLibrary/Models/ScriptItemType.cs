using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWhaddonShowClassLibrary.Models
{
    public class ScriptItemType
    {
        /// <summary>
        /// Identity of the Script Type.
        /// </summary>
        public int  ID { get; set; }
        /// <summary>
        /// The name of the script type. i.e. Show,Act,Scene,Line,Paragraph,Span
        /// </summary>
        public  int Title { get; set; }
    }
}

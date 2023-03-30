using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWhaddonShowClassLibrary.Models
{
    /// <summary>
    /// A new paragraph within the line
    /// </summary>
    public class Paragraph
    {
        /// <summary>
        /// Text contained with the paragraph.
        /// </summary>
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// Default text type of the paragraph (i.g. Dialogue, Action, Sub Header etc...)
        /// </summary>
        public TextType? Type { get; set; }
    }
}

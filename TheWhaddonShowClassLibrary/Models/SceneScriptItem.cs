using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWhaddonShowClassLibrary.Models
{
    /// <summary>
    /// Item on Script representing start of a new scene.
    /// </summary>
    public class SceneScriptItem : ScriptItem
    {
        /// <summary>
        /// Title for the scene.
        /// </summary>
        public string Title { get; set; } = "Currently No Title for Scene. (needs Correcting)" +
            "";

        /// <summary>
        /// A general synopsis of the scene and how it fits in with the rest of the show.
        /// </summary>
        public string Synopsis { get; set; } = string.Empty;

        /// <summary>
        /// Free text tag to help reference running themes etc.
        /// </summary>
        List<string> Tags = new List<string>();

    }
}

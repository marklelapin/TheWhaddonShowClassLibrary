using MyClassLibrary.LocalServerMethods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWhaddonShowClassLibrary.Models
{
    public class TagUpdate : LocalServerModelUpdate
    {

        public string Name { get; set; }

        public TagUpdate() { }

        public TagUpdate(string name,Guid Id) :base(Id)
        {
            Name = name;
        }

    }
}

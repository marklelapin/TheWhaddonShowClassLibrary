using MyClassLibrary.LocalServerMethods.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWhaddonShowClassLibrary.Models;

namespace TheWhaddonShowClassLibrary.Interfaces
{
    internal interface IPartFactory : ILocalServerModelFactory<Part,PartUpdate>
    {
    }
}

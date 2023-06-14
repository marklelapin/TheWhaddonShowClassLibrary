﻿using MyClassLibrary.LocalServerMethods;
using MyClassLibrary.LocalServerMethods.Interfaces;
using MyClassLibrary.LocalServerMethods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWhaddonShowClassLibrary.Models
{
    public class Person : LocalServerModel<PersonUpdate>
    {
        
        public Person() : base()
        {

        }
     
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class MySqlColName : Attribute
    {
        public string Name { get; set; }

        public MySqlColName(string name)
        {
            Name = name;
        }
    }
}

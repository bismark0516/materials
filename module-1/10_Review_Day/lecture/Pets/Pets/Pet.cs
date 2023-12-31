﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataType

{
    public class Pet
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return $"{Name} - {Type} - {Age}";
        }

    }
}

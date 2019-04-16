﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsApp.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Subject()
        {
        }

        public Subject(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}

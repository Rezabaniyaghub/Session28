﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class ClassRoom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte AgeRange { get; set; }
        public int SchoolId { get; set; }
        public virtual School School { get; set; }
    }
}

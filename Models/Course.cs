using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace U20431644_H05.Models
{
    public class Course
    {
        //TODO: Complete this
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Course(int iD, string name, string description)
        {
            ID = iD;
            Name = name;
            Description = description;
        }

        public Course()
        {

        }
    }
}

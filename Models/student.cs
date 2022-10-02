using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace U20431644_H05.Models
{
    public class Students
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime birthdate { get; set; }
        public char gender { get; set; }
        public string Sclass { get; set; }
        public int point { get; set; }

        public Students()
        {

        }
    }
}

using System;

namespace U20431644_H05.Models
{
    public class borrow
    {
        public int borrowID { get; set; }
        public int StudentID { get; set; }
        public int bookID { get; set; }
        public DateTime takendate { get; set; }
        public DateTime broughtDate { get; set; }
    }
}

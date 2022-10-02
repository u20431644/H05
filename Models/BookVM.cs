using System.Collections.Generic;

namespace U20431644_H05.Models
{
    public class BookVM
    {
        public List<book> booklist { get; set; }
        public List<author> authorList { get; set; }
        public List<type> typeList { get; set; }
        public List<borrow> borrowList { get; set; }
        public List<Students> studentList { get; set; }
    }
}

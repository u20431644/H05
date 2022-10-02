using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using U20431644_H05.Models;
using U20431644_H05.Data;

namespace U20431644_H05.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private SomeDataService dataService = SomeDataService.getInstance();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<book> books = dataService.GetBooks();
            List<author> authors = dataService.GetAuthors();
            List<type> types = dataService.GetTypes();
            List<borrow> borrows = dataService.GetBorrows();
            List<Students> students = dataService.getStudents();
            BookVM bookVM = new BookVM()
            {
                booklist = books,
                authorList = authors,
                typeList = types,
                borrowList = borrows,
                studentList = students
            };
            ViewBag.Message = bookVM;
            return View(bookVM);
        }

        public ActionResult ViewCourse(int courseID)
        {
            List<CourseAssignmentsMarking> courseAssignmnts = dataService.getAssignmentsOfCourse(courseID);
            return View(courseAssignmnts);
        }

        public IActionResult Students()
        {
            List<Students> students = dataService.getStudents();
            return View(students);
        }

        public ActionResult BookDetails(int BookID)
        {
            List<book> books = dataService.GetBooks();
            List<author> authors = dataService.GetAuthors();
            List<type> types = dataService.GetTypes();
            List<borrow> borrows = dataService.GetBorrows();
            List<Students> students = dataService.getStudents();
            BookVM bookVM = new BookVM()
            {
                booklist = books,
                authorList = authors,
                typeList = types,
                borrowList = borrows,
                studentList = students
            };
            ViewBag.Title = BookID;
            return View(bookVM);
        }
    }

}

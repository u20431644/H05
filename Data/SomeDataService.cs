using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Collections;
using U20431644_H05.Models;

namespace U20431644_H05.Data
{
    public class SomeDataService
    {

        SqlConnection myConnection = new SqlConnection("Data Source=MET-MA-P15\\SQLEXPRESS; Initial Catalog=Library1;Integrated Security=True");

        private static SomeDataService instance;
        public string connectionString;

        public static SomeDataService getInstance()
        {
            if (instance == null)
            {
                instance = new SomeDataService();
            }
            return instance;
        }

        public void setConnectionString(string someConnStr)
        {
            connectionString = someConnStr;
        }

        public List<Course> getAvailableCourses()
        {
            List<Course> data = new List<Course>();

            //TODO: Complete this
            try
            {
                myConnection.Open();
                SqlCommand myselect = new SqlCommand("Select * FROM students", myConnection);
                SqlDataReader myReader = myselect.ExecuteReader();

                while (myReader.Read())
                {
                    Console.WriteLine(myReader.Read());
                    Course course = new()
                    {
                        ID = (int)myReader["studentId"],
                        Name = (string)myReader["name"],
                        Description = (string)myReader["surname"]

                    };
                    data.Add(course);
                    //Console.WriteLine(course.ID.ToString(), course.Name, course.Description);
                    //Console.WriteLine(data);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                myConnection.Close();
            }
            return data;
        }

        public List<Students> getStudents()
        {
            List<Students> students = new List<Students>();
            try
            {
                myConnection.Open();
                SqlCommand myselect = new SqlCommand("Select * from students", myConnection);
                SqlDataReader myreader = myselect.ExecuteReader();

                while (myreader.Read())
                {
                    Students student = new Students
                    {
                        StudentId = Convert.ToInt32(myreader["studentId"]),
                        Name = Convert.ToString(myreader["name"]),
                        Surname = Convert.ToString(myreader["surname"]),
                        birthdate = Convert.ToDateTime(myreader["birthdate"]),
                        gender = Convert.ToChar(myreader["gender"]),
                        Sclass = Convert.ToString(myreader["class"]),
                        point = Convert.ToInt32(myreader["point"])
                    };
                    students.Add(student);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
            return students;
        }

        public List<book> GetBooks()
        {
            List<book> books = new List<book>();
            try
            {
                myConnection.Open();
                SqlCommand myselect = new SqlCommand("Select * from books", myConnection);
                SqlDataReader myreader = myselect.ExecuteReader();

                while (myreader.Read())
                {
                    book book = new book
                    {
                        BookID = (int)myreader["bookId"],
                        Title = (string)myreader["name"],
                        Pagecnt = (int)myreader["pagecount"],
                        point = (int)myreader["point"],
                        AuthorID = (int)myreader["authorId"],
                        typeID = (int)myreader["typeId"]
                    };
                    books.Add(book);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
            return books;
        }

        public List<author> GetAuthors()
        {
            List<author> authors = new List<author>();
            try
            {
                myConnection.Open();
                SqlCommand myselect = new SqlCommand("Select * from authors", myConnection);
                SqlDataReader myreader = myselect.ExecuteReader();

                while (myreader.Read())
                {
                    author auth = new author
                    {
                        AuthorID = (int)myreader["authorId"],
                        Aname = (string)myreader["name"],
                        Asurname = (string)myreader["surname"]
                    };
                    authors.Add(auth);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
            return authors;
        }

        public List<type> GetTypes()
        {
            List<type> types = new List<type>();
            try
            {
                myConnection.Open();
                SqlCommand myselect = new SqlCommand("Select * from types", myConnection);
                SqlDataReader myreader = myselect.ExecuteReader();

                while (myreader.Read())
                {
                    type typesrec = new type
                    {
                        typeID = (int)myreader["typeId"],
                        typename = (string)myreader["name"]
                    };
                    types.Add(typesrec);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
            return types;
        }

        public List<borrow> GetBorrows()
        {
            List<borrow> borrows = new List<borrow>();
            try
            {
                myConnection.Open();
                SqlCommand myselect = new SqlCommand("Select * from borrows", myConnection);
                SqlDataReader myreader = myselect.ExecuteReader();

                while (myreader.Read())
                {
                    borrow borrow = new borrow
                    {
                        borrowID = (int)myreader["borrowId"],
                        StudentID = (int)myreader["studentId"],
                        bookID = (int)myreader["bookId"],
                        takendate = (DateTime)myreader["takenDate"],
                        broughtDate = (DateTime)myreader["broughtDate"]
                    };
                    borrows.Add(borrow);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
            return borrows;
        }

        public List<CourseAssignmentsMarking> getAssignmentsOfCourse(int courseID)
        {
            List<CourseAssignmentsMarking> assignments = new List<CourseAssignmentsMarking>();
            try
            {
                myConnection.Open();
                SqlCommand myselect = new SqlCommand("Select CM.ID, CM.CourseID, CM.MarkerID, CM.StudentID, C.Name AS CNAME, " +
                "C.Description AS Cdescription, S.Name AS StudentName, ST.Name AS StaffName FROM CourseAssignmentsMarking CM " +
                "JOIN Courses C ON CM.CourseID = C.ID " +
                "JOIN Students S ON CM.StudentID = S.ID " +
                "JOIN Staff ST ON CM.MarkerID = ST.ID " +
                "WHERE CM.CourseID=" + courseID, myConnection);
                Console.WriteLine(myselect.ToString());
                SqlDataReader myReader = myselect.ExecuteReader();
                while (myReader.Read())
                {
                    Console.WriteLine("HH");
                    CourseAssignmentsMarking courseAssignmentsMarking = new()
                    {
                        AssignmentID = (int)myReader["ID"],
                        CourseID = (int)myReader["CourseID"],
                        MarkerID = (int)myReader["MarkerID"],
                        MarkerName = (string)myReader["StaffName"],
                        StudentID = (int)myReader["StudentID"],
                        StudentName = (string)myReader["StudentName"],
                        CourseName = (string)myReader["CNAME"],
                        Description = (string)myReader["Cdescription"]
                    };
                    assignments.Add(courseAssignmentsMarking);
                    //Console.WriteLine(course.ID.ToString(), course.Name, course.Description);
                    Console.WriteLine(courseAssignmentsMarking);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                myConnection.Close();
            }
            return assignments;
            }


    }
}

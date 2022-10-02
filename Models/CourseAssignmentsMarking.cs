namespace U20431644_H05.Models
{
    public class CourseAssignmentsMarking
    {
        public int AssignmentID { get; set; }
        public int CourseID { get; set; }
        public int MarkerID { get; set; }
        public string MarkerName { get; set; }
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }

        public CourseAssignmentsMarking(int assignmentID, int courseID, int markerID, string markerName, int studentID, string studentName, string courseName, string description)
        {
            AssignmentID = assignmentID;
            CourseID = courseID;
            MarkerID = markerID;
            MarkerName = markerName;
            StudentID = studentID;
            StudentName = studentName;
            CourseName = courseName;
            Description = description;
        }

        public CourseAssignmentsMarking()
        {

        }
    }
}

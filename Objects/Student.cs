using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace Registrar
{
  public class Student
  {
    private int Id;
    private string Name;
    private DateTime EnrollmentDate;
    int DepartmentId;

    public Student(string name, DateTime enrollmentDate, int departmentId, int id = 0)
    {
      Id = id;
      Name = name;
      EnrollmentDate = enrollmentDate;
      DepartmentId = departmentId;
    }

    public int GetId()
    {
      return Id;
    }
    public string GetName()
    {
      return Name;
    }
    public DateTime GetEnrollmentDate()
    {
      return EnrollmentDate;
    }
    public int GetDepartmentId()
    {
      return DepartmentId;
    }
    public void SetName(string newName)
    {
      Name = newName;
    }
    public void SetEnrollmentDate(DateTime date)
    {
      EnrollmentDate = date;
    }
    public void SetDepartmentId(int departmentId)
    {
      DepartmentId = departmentId;
    }

    public override bool Equals(System.Object otherStudent)
    {
      if(!(otherStudent is Student))
      {
        return false;
      }
      else
      {
        Student newStudent = (Student) otherStudent;
        bool idEquality = this.GetId() == newStudent.GetId();
        bool nameEquality = this.GetName() == newStudent.GetName();
        bool dateEquality = this.GetEnrollmentDate() == newStudent.GetEnrollmentDate();
        bool departmentIdEquality = this.GetDepartmentId() == newStudent.GetDepartmentId();
        return (idEquality && nameEquality && dateEquality && departmentIdEquality);
      }
    }

    public static List<Student> GetAll()
    {
      List<Student> allStudents = new List<Student> {};

      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM students ORDER BY name DESC;", conn);
      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int studentId = rdr.GetInt32(0);
        string studentName = rdr.GetString(1);
        DateTime studentEnrollmentDate = rdr.GetDateTime(2);
        int departmentId = rdr.GetInt32(3);
        Student newStudent = new Student(studentName, studentEnrollmentDate, departmentId , studentId);
        allStudents.Add(newStudent);
      }
      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
      return allStudents;
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr;
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO students (name, enrollment_date, department_id) OUTPUT INSERTED.id VALUES (@StudentName, @StudentEnrollmentDate, @DepartmentId);", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@StudentName";
      nameParameter.Value = this.GetName();
      cmd.Parameters.Add(nameParameter);

      SqlParameter dateParameter = new SqlParameter();
      dateParameter.ParameterName = "@StudentEnrollmentDate";
      dateParameter.Value = this.GetEnrollmentDate();
      cmd.Parameters.Add(dateParameter);

      SqlParameter departmentIDParameter = new SqlParameter();
      departmentIDParameter.ParameterName = "@DepartmentID";
      departmentIDParameter.Value = this.GetDepartmentId();
      cmd.Parameters.Add(departmentIDParameter);

      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this.Id = rdr.GetInt32(0);
      }
      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
    }

    public static Student Find(int id)
    {
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM students WHERE id = @StudentId;", conn);
      SqlParameter studentIdParameter = new SqlParameter();
      studentIdParameter.ParameterName = "@StudentId";
      studentIdParameter.Value = id.ToString();
      cmd.Parameters.Add(studentIdParameter);

      rdr = cmd.ExecuteReader();

      int foundStudentId = 0;
      string foundStudentName = null;
      DateTime foundDate = new DateTime();
      int foundStudentDepartmentId = 0;

      while(rdr.Read())
      {
        foundStudentId = rdr.GetInt32(0);
        foundStudentName = rdr.GetString(1);
        foundDate = rdr.GetDateTime(2);
        foundStudentDepartmentId = rdr.GetInt32(3);
      }
      Student foundStudent = new Student(foundStudentName, foundDate, foundStudentDepartmentId, foundStudentId);

      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
      return foundStudent;
    }

    public void Update(string newName, DateTime newDate)
    {
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr;
      conn.Open();

      SqlCommand cmd = new SqlCommand("UPDATE students SET name = @StudentName, enrollment_date = @StudentEnrolledDate OUTPUT INSERTED.name, INSERTED.enrollment_date WHERE id = @StudentId;", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@StudentName";
      nameParameter.Value = newName;
      cmd.Parameters.Add(nameParameter);

      SqlParameter dateParameter = new SqlParameter();
      dateParameter.ParameterName = "@StudentEnrolledDate";
      dateParameter.Value = newDate;
      cmd.Parameters.Add(dateParameter);

      SqlParameter studentIdParameter = new SqlParameter();
      studentIdParameter.ParameterName = "@StudentId";
      studentIdParameter.Value = this.GetId();
      cmd.Parameters.Add(studentIdParameter);

      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this.Name = rdr.GetString(0);
        this.EnrollmentDate = rdr.GetDateTime(1);
      }

      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
    }

    public void AddCourse(Course newCourse)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO students_courses (student_id, course_id) VALUES (@StudentId, @CourseId);", conn);
      SqlParameter studentIdParameter = new SqlParameter();
      studentIdParameter.ParameterName = "@StudentId";
      studentIdParameter.Value = this.GetId();
      cmd.Parameters.Add(studentIdParameter);

      SqlParameter courseIdParameter = new SqlParameter();
      courseIdParameter.ParameterName = "@CourseId";
      courseIdParameter.Value = newCourse.GetId();
      cmd.Parameters.Add(courseIdParameter);

      cmd.ExecuteNonQuery();

      if(conn != null)
      {
        conn.Close();
      }
    }

    public List<Course> GetCourses()
    {
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT courses. * FROM students JOIN students_courses ON (students.id = students_courses.student_id) JOIN courses ON (students_courses.course_id = courses.id) WHERE students.id = @StudentId;", conn);
      SqlParameter studentIdParameter = new SqlParameter();
      studentIdParameter.ParameterName = "@StudentId";
      studentIdParameter.Value = this.GetId().ToString();
      cmd.Parameters.Add(studentIdParameter);

      rdr = cmd.ExecuteReader();
      List<Course> courses = new List<Course> {};
      while(rdr.Read())
      {
        int courseId = rdr.GetInt32(0);
        string courseName = rdr.GetString(1);
        string courseNumber = rdr.GetString(2);
        Course newCourse = new Course(courseName, courseNumber, courseId);
        courses.Add(newCourse);
      }

      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
      return courses;
    }

    public void Delete()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM students WHERE id = @StudentId; DELETE FROM students_courses WHERE student_id = @StudentId;", conn);

      SqlParameter studentIdParameter = new SqlParameter();
      studentIdParameter.ParameterName = "@StudentId";
      studentIdParameter.Value = this.GetId();
      cmd.Parameters.Add(studentIdParameter);

      cmd.ExecuteNonQuery();

      if(conn != null)
      {
        conn.Close();
      }
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM students;", conn);
      cmd.ExecuteNonQuery();
    }
  }
}

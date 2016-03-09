using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace Registrar
{
  public class Department
  {
    private int Id;
    private string Name;

    public Department(string name, int id = 0)
    {
      Id = id;
      Name = name;
    }

    public int GetId()
    {
      return Id;
    }
    public string GetName()
    {
      return Name;
    }

    public void SetName(string newName)
    {
      Name = newName;
    }

    public override bool Equals(System.Object otherDepartment)
    {
      if(!(otherDepartment is Department))
      {
        return false;
      }
      else
      {
        Department newDepartment = (Department) otherDepartment;
        bool idEquality = this.GetId() == newDepartment.GetId();
        bool nameEquality = this.GetName() == newDepartment.GetName();
        return (idEquality && nameEquality);
      }
    }

    public static List<Department> GetAll()
    {
      List<Department> allDepartments = new List<Department> {};

      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM departments ORDER BY name DESC;", conn);
      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int departmentId = rdr.GetInt32(0);
        string departmentName = rdr.GetString(1);
        Department newDepartment = new Department(departmentName, departmentId);
        allDepartments.Add(newDepartment);
      }
      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
      return allDepartments;
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr;
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO departments (name) OUTPUT INSERTED.id VALUES (@DepartmentName);", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@DepartmentName";
      nameParameter.Value = this.GetName();
      cmd.Parameters.Add(nameParameter);

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

    // public static Student Find(int id)
    // {
    //   SqlConnection conn = DB.Connection();
    //   SqlDataReader rdr = null;
    //   conn.Open();
    //
    //   SqlCommand cmd = new SqlCommand("SELECT * FROM departments WHERE id = @DepartmentId;", conn);
    //   SqlParameter departmentIdParameter = new SqlParameter();
    //   departmentIdParameter.ParameterName = "@DepartmentId";
    //   departmentIdParameter.Value = id.ToString();
    //   cmd.Parameters.Add(departmentIdParameter);
    //
    //   rdr = cmd.ExecuteReader();
    //
    //   int foundDepartmentId = 0;
    //   string foundDepartmentName = null;
    //
    //   while(rdr.Read())
    //   {
    //     foundDepartmentId = rdr.GetInt32(0);
    //     foundDepartmentName = rdr.GetString(1);
    //   }
    //   Student foundDepartment = new Department(foundDepartmentName, foundDepartmentId);
    //
    //   if(rdr != null)
    //   {
    //     rdr.Close();
    //   }
    //   if(conn != null)
    //   {
    //     conn.Close();
    //   }
    //   return foundDepartment;
    // }
    //
    // public void Update(string newName)
    // {
    //   SqlConnection conn = DB.Connection();
    //   SqlDataReader rdr;
    //   conn.Open();
    //
    //   SqlCommand cmd = new SqlCommand("UPDATE departments SET name = @DepartmentName OUTPUT INSERTED.name WHERE id = @DepartmentId;", conn);
    //
    //   SqlParameter nameParameter = new SqlParameter();
    //   nameParameter.ParameterName = "@DepartmentName";
    //   nameParameter.Value = newName;
    //   cmd.Parameters.Add(nameParameter);
    //
    //   SqlParameter departmentIdParameter = new SqlParameter();
    //   departmentIdParameter.ParameterName = "@DepartmentId";
    //   departmentIdParameter.Value = this.GetId();
    //   cmd.Parameters.Add(departmentIdParameter);
    //
    //   rdr = cmd.ExecuteReader();
    //
    //   while(rdr.Read())
    //   {
    //     this.Name = rdr.GetString(0);
    //   }
    //
    //   if(rdr != null)
    //   {
    //     rdr.Close();
    //   }
    //   if(conn != null)
    //   {
    //     conn.Close();
    //   }
    // }
    // //
    // // public void AddCourse(Course newCourse)
    // // {
    // //   SqlConnection conn = DB.Connection();
    // //   conn.Open();
    // //
    // //   SqlCommand cmd = new SqlCommand("INSERT INTO students_courses (student_id, course_id) VALUES (@StudentId, @CourseId);", conn);
    // //   SqlParameter studentIdParameter = new SqlParameter();
    // //   studentIdParameter.ParameterName = "@StudentId";
    // //   studentIdParameter.Value = this.GetId();
    // //   cmd.Parameters.Add(studentIdParameter);
    // //
    // //   SqlParameter courseIdParameter = new SqlParameter();
    // //   courseIdParameter.ParameterName = "@CourseId";
    // //   courseIdParameter.Value = newCourse.GetId();
    // //   cmd.Parameters.Add(courseIdParameter);
    // //
    // //   cmd.ExecuteNonQuery();
    // //
    // //   if(conn != null)
    // //   {
    // //     conn.Close();
    // //   }
    // // }
    //
    // public List<Course> GetCourses()
    // {
    //   SqlConnection conn = DB.Connection();
    //   SqlDataReader rdr = null;
    //   conn.Open();
    //
    //   SqlCommand cmd = new SqlCommand("SELECT * FROM courses WHERE department_id = @DepartmentId", conn);
    //   SqlParameter departmentIdParameter = new SqlParameter();
    //   departmentIdParameter.ParameterName = "@DepartmentId";
    //   departmentIdParameter.Value = this.GetId();
    //   cmd.Parameters.Add(departmentIdParameter);
    //
    //   rdr = cmd.ExecuteReader();
    //   List<Course> courses = new List<Course> {};
    //   while(rdr.Read())
    //   {
    //     int courseId = rdr.GetInt32(0);
    //     string courseName = rdr.GetString(1);
    //     string courseNumber = rdr.GetString(2);
    //     Course newCourse = new Course(courseName, courseNumber, courseId);
    //     courses.Add(newCourse);
    //   }
    //
    //   if(rdr != null)
    //   {
    //     rdr.Close();
    //   }
    //   if(conn != null)
    //   {
    //     conn.Close();
    //   }
    //   return courses;
    // }
    //
    // public List<Student> GetStudents()
    // {
    //   SqlConnection conn = DB.Connection();
    //   SqlDataReader rdr = null;
    //   conn.Open();
    //
    //   SqlCommand cmd = new SqlCommand("SELECT * FROM students WHERE department_id = @DepartmentId", conn);
    //   SqlParameter departmentIdParameter = new SqlParameter();
    //   departmentIdParameter.ParameterName = "@DepartmentId";
    //   departmentIdParameter.Value = this.GetId();
    //   cmd.Parameters.Add(departmentIdParameter);
    //
    //   rdr = cmd.ExecuteReader();
    //   List<Student> students = new List<Student> {};
    //   while(rdr.Read())
    //   {
    //     int studentId = rdr.GetInt32(0);
    //     string studentName = rdr.GetString(1);
    //     DateTime studentEnrollmentDate = rdr.GetDateTime(2);
    //     Student newStudent = new Student(studentName, studentEnrollmentDate, studentId);
    //     students.Add(newStudent);
    //   }
    //
    //   if(rdr != null)
    //   {
    //     rdr.Close();
    //   }
    //   if(conn != null)
    //   {
    //     conn.Close();
    //   }
    //   return students;
    // }
    //
    // // public void Delete()
    // // {
    // //   SqlConnection conn = DB.Connection();
    // //   conn.Open();
    // //
    // //   SqlCommand cmd = new SqlCommand("DELETE FROM students WHERE id = @StudentId; DELETE FROM students_courses WHERE student_id = @StudentId;", conn);
    // //
    // //   SqlParameter studentIdParameter = new SqlParameter();
    // //   studentIdParameter.ParameterName = "@StudentId";
    // //   studentIdParameter.Value = this.GetId();
    // //   cmd.Parameters.Add(studentIdParameter);
    // //
    // //   cmd.ExecuteNonQuery();
    // //
    // //   if(conn != null)
    // //   {
    // //     conn.Close();
    // //   }
    // // }
    //
    // public static void DeleteAll()
    // {
    //   SqlConnection conn = DB.Connection();
    //   conn.Open();
    //   SqlCommand cmd = new SqlCommand("DELETE FROM departments;", conn);
    //   cmd.ExecuteNonQuery();
    // }
  }
}

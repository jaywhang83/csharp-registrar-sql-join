using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace Registrar
{
  public class Course
  {
    private int Id;
    private string Name;
    private string CourseNumber;

    public Course(string name, string courseNumber, int id = 0)
    {
      Id = id;
      Name = name;
      CourseNumber = courseNumber;
    }

    public int GetId()
    {
      return Id;
    }
    public string GetName()
    {
      return Name;
    }
    public string GetCourseNumber()
    {
      return CourseNumber;
    }
    public void SetName(string name)
    {
      Name = name;
    }
    public void SetCourseNumber(string courseNumber)
    {
      CourseNumber = courseNumber;
    }

    public override bool Equals(System.Object otherCourse)
    {
      if(!(otherCourse is Course))
      {
        return false;
      }
      else
      {
        Course newCourse = (Course) otherCourse;
        bool idEquality = this.GetId() == newCourse.GetId();
        bool nameEquality = this.GetName() == newCourse.GetName();
        bool courseNumberEquality = this.GetCourseNumber() == newCourse.GetCourseNumber();
        return (idEquality && nameEquality && courseNumberEquality);
      }
    }

    public static List<Course> GetAll()
    {
      List<Course> allCourses = new List<Course> {};

      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM courses ORDER BY name DESC;", conn);
      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int courseId = rdr.GetInt32(0);
        string courseName = rdr.GetString(1);
        string courseNumber = rdr.GetString(2);
        Course newCourse = new Course(courseName, courseNumber, courseId);
        allCourses.Add(newCourse);
      }

      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
      return allCourses;
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM courses;", conn);
      cmd.ExecuteNonQuery();
    }
  }

}

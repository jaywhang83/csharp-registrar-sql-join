using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Registrar
{
  public class CourseTest : IDisposable
  {
    public CourseTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Registrar_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_CoursesEmptyAtFirst()
    {
        int result = Course.GetAll().Count;

        Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Equal_overrideTrueForSameDescription()
    {
      Course testCourse1 = new Course("CS 101 Intro to Computer Schience", "CS101-2");
      Course testCourse2 = new Course("CS 101 Intro to Computer Schience", "CS101-2");

      Assert.Equal(testCourse1, testCourse2);
    }

    [Fact]
    public void Test_Save()
    {
      Course testCourse = new Course("CS 101 Intro to Computer Schience", "CS101-2");
      testCourse.Save();

      List<Course> result = Course.GetAll();
      List<Course> testList = new List<Course> {testCourse};

      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Save_AssignsIdToOBject()
    {
      Course testCourse = new Course("CS 101 Intro to Computer Schience", "CS101-2");

      testCourse.Save();

      Course savedCourse = Course.GetAll()[0];

      int result = savedCourse.GetId();
      int testId = testCourse.GetId();

      Assert.Equal(result, testId);  
    }

    public void Dispose()
    {
      Course.DeleteAll();
    }
  }
}

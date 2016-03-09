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
      Course testCourse1 = new Course("CS 101 Intro to Computer Schience", "CS!101-2");
      Course testCourse2 = new Course("CS 101 Intro to Computer Schience", "CS!101-2");

      Assert.Equal(testCourse1, testCourse2);
    }

    public void Dispose()
    {
      Course.DeleteAll();
    }
  }
}

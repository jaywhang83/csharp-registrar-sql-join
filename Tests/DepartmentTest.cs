using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Registrar
{
  public class DepartmentTest : IDisposable
  {
    public DepartmentTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Registrar_test;Integrated Security=SSPI;";
    }

    // [Fact]
    // public void Test_DepartmentEmptyAtFirst()
    // {
    //   int result = Course.GetAll().Count;
    // }

    [Fact]
    public void Test_Equal_overrideTrueForSameName()
    {
      Department testDepartment1 = new Department("Computer Science");
      Department testDepartment2 = new Department("Computer Science");

      Assert.Equal(testDepartment1, testDepartment2);
    }
    [Fact]
    public void Test_Save()
    {
      Department testDepartment = new Department("Accounting");
      testDepartment.Save();

      List<Department> result = Department.GetAll();
      List<Department> testList = new List<Department> {testDepartment};

      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Save_AssignsIdToOBject()
    {
      Department testDepartment = new Department("Accounting");
      testDepartment.Save();

      Department savedDepartment = Department.GetAll()[0];

      int resultId = savedDepartment.GetId();
      int testId = testDepartment.GetId();

      Assert.Equal(testId, resultId);
    }

    [Fact]
    public void Test_Find_FindsDepartmentInDatabase()
    {
      Department testDepartment = new Department("Computer Science");
      testDepartment.Save();

      Department foundDepartment = Department.Find(testDepartment.GetId());

      Assert.Equal(testDepartment, foundDepartment);
    }

    [Fact]
    public void Test_Update_UpdateDepartment()
    {
      Department testDepartment = new Department("Computer Science");
      testDepartment.Save();

      string newName = "Software Engineering";
      testDepartment.Update(newName);

      string resultName = testDepartment.GetName();

      Assert.Equal(newName, resultName);
    }

    [Fact]
    public void Test_GetCourses_ReturnsAllCourseseInDepartment()
    {
      Department testDepartment = new Department("Accounting");
      testDepartment.Save();

      Course testCourse1 = new Course("Intro to Accounting", "ACTG101", testDepartment.GetId());
      testCourse1.Save();

      Course testCourse2 = new Course("Cost Accounting", "ACTG380", testDepartment.GetId());
      testCourse2.Save();

      List<Course> result = testDepartment.GetCourses();
      List<Course> testList = new List<Course> {testCourse1, testCourse2};

      Assert.Equal(testList, result);
    }

    public void Dispose()
    {
      Department.DeleteAll();
      Course.DeleteAll();
      Student.DeleteAll();
    }
  }
}

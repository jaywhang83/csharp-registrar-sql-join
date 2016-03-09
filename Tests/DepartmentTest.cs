using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Registrar
{
  public class DepartmentTest
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

    // public void Dispose()
    // {
    //   Department.DeleteAll();
    // }
  }
}

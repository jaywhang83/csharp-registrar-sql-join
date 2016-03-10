using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Registrar
{
  public class StudentTest : IDisposable
  {
    public StudentTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=registrar_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_StudentsEmptyAtFirst()
    {
      int result = Student.GetAll().Count;

      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Equal_overrideTrueForSameName()
    {
      Department testDepartment = new Department("Computer Science");
      testDepartment.Save();

      DateTime testDate = new DateTime(2016, 3, 10);
      Student firstStudent = new Student("Wade Wilson", testDate, testDepartment.GetId());
      Student secondStudent = new Student("Wade Wilson", testDate, testDepartment.GetId());

      Assert.Equal(firstStudent, secondStudent);
    }

    [Fact]
    public void Test_Save()
    {
      Department testDepartment = new Department("Computer Science");
      testDepartment.Save();

      DateTime testDate = new DateTime(2016, 3, 10);
      Student testStudent = new Student("Wade Wilson", testDate, testDepartment.GetId());
      testStudent.Save();

      List<Student> result = Student.GetAll();
      List<Student> testList = new List<Student> {testStudent};

      Assert.Equal(result, testList);
    }

    [Fact]
    public void Test_Save_AssingsIdToObject()
    {
      Department testDepartment = new Department("Computer Science");
      testDepartment.Save();

      DateTime testDate = new DateTime(2016, 3, 10);
      Student testStudent = new Student("Wade Wilson", testDate, testDepartment.GetId());

      testStudent.Save();

      Student savedStudent = Student.GetAll()[0];

      int result = savedStudent.GetId();
      int testId = testStudent.GetId();

      Assert.Equal(result, testId);
    }

    [Fact]
    public void Test_Find_FindsTaskInDatabase()
    {
      Department testDepartment = new Department("Computer Science");
      testDepartment.Save();

      DateTime testDate = new DateTime(2016, 3, 10);
      Student testStudent = new Student("Wade Wilson", testDate, testDepartment.GetId());
      testStudent.Save();

      Student foundStudent = Student.Find(testStudent.GetId());

      Assert.Equal(testStudent, foundStudent);
    }

    [Fact]
    public void Test_Update_UpdatesStudent()
    {
      Department testDepartment = new Department("Computer Science");
      testDepartment.Save();

      DateTime testDate = new DateTime(2016, 3, 10);
      Student testStudent = new Student("Wade Wilson", testDate, testDepartment.GetId());
      testStudent.Save();

      string newName = "Tony Stark";
      DateTime newDate = new DateTime(2016, 3, 15);

      testStudent.Update(newName, newDate);

      string resultName = testStudent.GetName();
      DateTime resultDate = testStudent.GetEnrollmentDate();

      Assert.Equal(newName, resultName);
      Assert.Equal(newDate, resultDate);
    }

    [Fact]
    public void Test_AddCourse_AddsCoureToStudent()
    {
      Department testDepartment = new Department("Computer Science");
      testDepartment.Save();

      DateTime testDate = new DateTime(2016, 3, 10);
      Student testStudent = new Student("Wade Wilson", testDate, testDepartment.GetId());
      testStudent.Save();

      Course testCourse1 = new Course("CS161 Intro to object oriented programming", "CS161-2", testDepartment.GetId());
      testCourse1.Save();

      Course testCourse2 = new Course("CS50 Intro to computer science", "CS161-2", testDepartment.GetId());
      testCourse2.Save();

      testStudent.AddCourse(testCourse1);
      testStudent.AddCourse(testCourse2);

      List<Course> result = testStudent.GetCourses();
      foreach(Course i in result)
      {
        Console.WriteLine("Here1:" + i.GetName() + "id:" + i.GetDepartmentId() + " depId: "+ i.GetDepartmentId());
      }
      List<Course> testList = new List<Course> {testCourse1, testCourse2};
      foreach(Course j in testList)
      {
        Console.WriteLine("test1:" + j.GetName() + "id: " + j.GetId() + " depId: " + j.GetDepartmentId());
      }

      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test__GetCourses_ReturnsAllCoursesForStudent()
    {
      Department testDepartment = new Department("Computer Science");
      testDepartment.Save();
      DateTime testDate = new DateTime(2016, 3, 10);

      Student testStudent = new Student("Wade Wilson", testDate, testDepartment.GetId());
      testStudent.Save();

      Course testCourse1 = new Course("CS162 Intro to object oriented programming", "CS161-2", testDepartment.GetId());
      testCourse1.Save();

      Course testCourse2 = new Course("CS50 Intro to computer science", "CS161-2", testDepartment.GetId());
      testCourse2.Save();

      testStudent.AddCourse(testCourse1);

      List<Course> result = testStudent.GetCourses();
      foreach(Course i in result)
      {
        Console.WriteLine("here: " + i.GetName() + i.GetDepartmentId());
      }
      List<Course> testList = new List<Course> {testCourse1};
      foreach(Course j in testList)
      {
        Console.WriteLine("testList: " + j.GetName() + j.GetDepartmentId());
      }

      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Delete_DeletesStudentAssociationsFromDatabase()
    {
      Department testDepartment = new Department("Computer Science");
      testDepartment.Save();
      DateTime testDate = new DateTime(2016, 3, 10);

      Student testStudent = new Student("Wade Wilson", testDate, testDepartment.GetId());
      testStudent.Save();

      string testName = "CS101 Intro to computer Science";
      string testNumber = "CS101-2";
      Course testCourse = new Course(testName, testNumber, testDepartment.GetId());
      testCourse.Save();

      testStudent.AddCourse(testCourse);
      testStudent.Delete();

      List<Student> resultStudentCourses = testCourse.GetStudents();
      List<Student> testList = new List<Student> {};

      Assert.Equal(resultStudentCourses, testList);
    }

    public void Dispose()
    {
      Student.DeleteAll();
      Course.DeleteAll();
      Department.DeleteAll(); 
    }
  }
}

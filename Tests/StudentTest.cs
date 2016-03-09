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
      DateTime testDate = new DateTime(2016, 3, 10);
      Student firstStudent = new Student("Wade Wilson", testDate);
      Student secondStudent = new Student("Wade Wilson", testDate);

      Assert.Equal(firstStudent, secondStudent);
    }

    [Fact]
    public void Test_Save()
    {
      DateTime testDate = new DateTime(2016, 3, 10);
      Student testStudent = new Student("Wade Wilson", testDate);
      testStudent.Save();

      List<Student> result = Student.GetAll();
      List<Student> testList = new List<Student> {testStudent};

      Assert.Equal(result, testList);
    }

    [Fact]
    public void Test_Save_AssingsIdToObject()
    {
      DateTime testDate = new DateTime(2016, 3, 10);
      Student testStudent = new Student("Wade Wilson", testDate);

      testStudent.Save();

      Student savedStudent = Student.GetAll()[0];

      int result = savedStudent.GetId();
      int testId = testStudent.GetId();

      Assert.Equal(result, testId);
    }

    [Fact]
    public void Test_Find_FindsTaskInDatabase()
    {
      DateTime testDate = new DateTime(2016, 3, 10);
      Student testStudent = new Student("Wade Wilson", testDate);
      testStudent.Save();

      Student foundStudent = Student.Find(testStudent.GetId());

      Assert.Equal(testStudent, foundStudent);
    }

    [Fact]
    public void Test_Update_UpdatesStudent()
    {
      DateTime testDate = new DateTime(2016, 3, 10);
      Student testStudent = new Student("Wade Wilson", testDate);
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
      DateTime testDate = new DateTime(2016, 3, 10);
      Student testStudent = new Student("Wade Wilson", testDate);
      testStudent.Save();

      Course testCourse1 = new Course("CS161 Intro to object oriented programming", "CS161-2");
      testCourse1.Save();

      Course testCourse2 = new Course("CS50 Intro to computer science", "CS161-2");
      testCourse2.Save();

      testStudent.AddCourse(testCourse1);
      testStudent.AddCourse(testCourse2);

      List<Course> result = testStudent.GetCourses();
      List<Course> testList = new List<Course> {testCourse1, testCourse2};

      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test__GetCourses_ReturnsAllCoursesForStudent()
    {
      DateTime testDate = new DateTime(2016, 3, 10);
      Student testStudent = new Student("Wade Wilson", testDate);
      testStudent.Save();

      Course testCourse1 = new Course("CS161 Intro to object oriented programming", "CS161-2");
      testCourse1.Save();

      Course testCourse2 = new Course("CS50 Intro to computer science", "CS161-2");
      testCourse2.Save();

      testStudent.AddCourse(testCourse1);

      List<Course> result = testStudent.GetCourses();
      List<Course> testList = new List<Course> {testCourse1};

      Assert.Equal(testList, result);
    }

    public void Dispose()
    {
      Student.DeleteAll();
    }
  }
}

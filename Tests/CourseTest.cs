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

    [Fact]
    public void Test_Find_FindsCoruseInDatabase()
    {
      Course testCourse = new Course ("CS 101 Intro to Computer Schience", "CS101-2");
      testCourse.Save();

      Course foundCourse = Course.Find(testCourse.GetId());

      Assert.Equal(testCourse, foundCourse);
    }

    [Fact]
    public void Test_Update_UpdatesCourse()
    {
      Course testCourse = new Course ("CS 101 Intro to Computer Schience", "CS101-2");
      testCourse.Save();

      string newName = "CS161 Intro to Object Oriented Programming";
      string newCourseNumber = "CS161-3";

      testCourse.Update(newName, newCourseNumber);

      string resultName = testCourse.GetName();
      string resultCourseNumber = testCourse.GetCourseNumber();

      Assert.Equal(newName, resultName);
      Assert.Equal(newCourseNumber, resultCourseNumber);
    }

    [Fact]
    public void Test_AddStudent_AddsStudentToCourse()
    {
      Course testCourse = new Course("CS101 Intro to computer science", "CS101-2");
      testCourse.Save();

      DateTime testDate = new DateTime(2016, 3, 10);
      Student testStudent1 = new Student("Wade Wilson", testDate);
      testStudent1.Save();

      Student testStudent2 = new Student("Tony Stark", testDate);
      testStudent2.Save();

      testCourse.AddStudent(testStudent1);
      testCourse.AddStudent(testStudent2);

      List<Student> result = testCourse.GetStudents();
      List<Student> testList = new List<Student> {testStudent1, testStudent2};

      Assert.Equal(testList, result);
    }

    public void Test_GetStudents_ReturnsAllStudentsInCourse()
    {
      Course testCourse = new Course("CS161 Intro to object oriented programming", "CS161-2");
      testCourse.Save();

      DateTime testDate1 = new DateTime(2016, 3, 10);
      Student testStudent1 = new Student("Wade Wilson", testDate1);
      testStudent1.Save();

      DateTime testDate2 = new DateTime(2016, 3, 15);
      Student testStudent2 = new Student("Tony Stark", testDate2);
      testStudent2.Save();

      testCourse.AddStudent(testStudent2);

      List<Student> result = testCourse.GetStudents();
      List<Student> testList = new List<Student> {testStudent2};

      Assert.Equal(testList, result);
    }

    public void Dispose()
    {
      Course.DeleteAll();
    }
  }
}

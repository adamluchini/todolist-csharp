using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ToDoList
{
  public class ToDoListTest : IDisposable
  {

    public ToDoListTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=todolist;Integrated Security=SSPI;";
    }

    public void Dispose()
    {
      Task.DeleteAll();
    }
    [Fact]
   public void Test_EqualOverrideTrueForSameDescription()
   {
     //Arrange, Act
     DateTime? taskDate = new DateTime(2016, 7, 12);
     Task firstTask = new Task("Mow the lawn", taskDate, 1);
     Task secondTask = new Task("Mow the lawn", taskDate, 1);

     //Assert
     Assert.Equal(firstTask, secondTask);
   }

   [Fact]
   public void Test_Save()
   {
     //Arrange
     DateTime? taskDate = new DateTime(2016, 7, 12);
     Task testTask = new Task("Mow the lawn", taskDate, 1);
     testTask.Save();

     //Act
     List<Task> result = Task.GetAll();
     List<Task> testList = new List<Task>{testTask};

     //Assert
     Assert.Equal(testList, result);
   }

   [Fact]
   public void Test_SaveAssignsIdToObject()
   {
     //Arrange
     DateTime? taskDate = new DateTime(2016, 7, 12);
     Task testTask = new Task("Mow the lawn", taskDate, 1);
     testTask.Save();

     //Act
     Task savedTask = Task.GetAll()[0];

     int result = savedTask.GetId();
     int testId = testTask.GetId();

     //Assert
     Assert.Equal(testId, result);
   }

   [Fact]
   public void Test_FindFindsTaskInDatabase()
   {
     DateTime? taskDate = new DateTime(2016, 7, 12);
     //Arrange
     Task testTask = new Task("Mow the lawn", taskDate, 1);
     testTask.Save();

     //Act
     Task foundTask = Task.Find(testTask.GetId());

     //Assert
     Assert.Equal(testTask, foundTask);
   }
  }
}

using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ToDoList
{
  public class ToDoListTest : IDisposable
  {
    // [Fact]
    // public void Test_DatabaseEmptyAtFirst()
    // {
    //   //Arrange and Act
    //   int result = Task.GetAll().Count;
    //
    //   //Assert
    //   Assert.Equal(0, result);
    // }
    //
    // [Fact]
    // public void Test_Equal_ReturnsTrueIfDescriptionsAreTheSame()
    // {
    //   //Arrange and Act
    //   Task firstTask = new Task("Mow the lawn");
    //   Task secondTask = new Task("Mow the lawn");
    //
    //   //Assert
    //   Assert.Equal(firstTask, secondTask);
    // }
    //
    // [Fact]
    // public void Test_Save_SavesToDatabase()
    // {
    //   //Arrange
    //   Task testTask = new Task ("Mow the lawn");
    //
    //   //Act
    //   testTask.Save();
    //   List<Task> result = Task.GetAll();
    //   List<Task> testList = new List<Task>{testTask};
    //
    //   //Assert
    //   Assert.Equal(testList, result);
    // }
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
     Task firstTask = new Task("Mow the lawn", 1);
     Task secondTask = new Task("Mow the lawn", 1);

     //Assert
     Assert.Equal(firstTask, secondTask);
   }

   [Fact]
   public void Test_Save()
   {
     //Arrange
     Task testTask = new Task("Mow the lawn", 1);
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
     Task testTask = new Task("Mow the lawn", 1);
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
     //Arrange
     Task testTask = new Task("Mow the lawn", 1);
     testTask.Save();

     //Act
     Task foundTask = Task.Find(testTask.GetId());

     //Assert
     Assert.Equal(testTask, foundTask);
   }
  }
}

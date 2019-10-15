using Microsoft.VisualStudio.TestTools.UnitTesting;
using todolist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using todolist.EntityModel;
using System.Windows.Controls;

namespace todolist.Tests

{
    [TestClass()]
    public class ListWindowTests
    {
        [TestMethod()]
        public void ValidTasksTest()
        {
            ListView lstToDo = new ListView();

            List<ToDoList> items = new List<ToDoList>();
            items.Add(new ToDoList() { Name = "John", UserId = 1 });
            items.Add(new ToDoList() { Name = "Jane", UserId = 1 });
            lstToDo.ItemsSource = items;

            lstToDo.SelectedItem = items.First();

            ListWindow lstWin = new ListWindow();
            Assert.AreEqual(lstWin.ValidList(lstToDo), true);
        }

    }
}
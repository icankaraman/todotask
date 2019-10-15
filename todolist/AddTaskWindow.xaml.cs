using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using todolist.EntityModel;

namespace todolist
{
    /// <summary>
    /// Interaction logic for AddTaskWindow.xaml
    /// </summary>
    public partial class AddTaskWindow : Window
    {
        ToDoDbContext db = new ToDoDbContext();
        User userModel = new User();
        List<long> hasListIds;
        public AddTaskWindow()
        {
            InitializeComponent();
        }
        public void GetUser(User user, List<long> listId)
        {
            userModel = user;
            hasListIds = listId;
        }
        
        public void ValidLines()
        {
            if (String.IsNullOrEmpty(txtTaskName.Text))
                MessageBox.Show("Task Name is required.");
            else if (dtDeadlineDate.SelectedDate == null || dtTaskDate.SelectedDate == null)
                MessageBox.Show("Date areas are required");
            else if (dtTaskDate.SelectedDate > dtDeadlineDate.SelectedDate)
                MessageBox.Show("Task Date can't bigger than Deadline Date.");
            else
                AddLines();
        }

        public void AddLines()
        {
            ToDoTask taskModel = new ToDoTask();

            taskModel.Name = txtTaskName.Text;
            taskModel.UserId = userModel.Id;
            taskModel.ListId = hasListIds.First();
            taskModel.CreateDate = dtTaskDate.SelectedDate;
            taskModel.UpdateDate = DateTime.Now;
            taskModel.DeadlineDate = dtDeadlineDate.SelectedDate;
            taskModel.Description = txtDescription.Text;
            taskModel.Status = 0;
            db.ToDoTasks.Add(taskModel);
            db.SaveChanges();
            MessageBox.Show("Task added!");
            
            var TaskWindow = new TasksWindow();
            TaskWindow.Show();
            TaskWindow.GetData(userModel, hasListIds);
            this.Close();
        }

        private void btnCreateTask_Click(object sender, RoutedEventArgs e)
        {
            ValidLines();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            var TaskWindow = new TasksWindow();
            TaskWindow.Show();
            TaskWindow.GetData(userModel,hasListIds);
            this.Close();
        }
    }
}

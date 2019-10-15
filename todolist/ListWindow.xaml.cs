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
    /// Interaction logic for ListWindow.xaml
    /// </summary>
    public partial class ListWindow : Window
    {
        public ListWindow()
        {
            InitializeComponent();
        }
        User user;
        ToDoList toDoListModel = new ToDoList();
        ToDoDbContext db = new ToDoDbContext();
        public void GetUser(User userModel)
        {
            spAddToDo.Visibility = Visibility.Hidden;
            user = userModel;
            lblWelcome.Content = $"Welcome {user.Name} !";
            var data = db.ToDoLists.AsQueryable().Where(x => x.UserId == user.Id).ToList();
            if (data.Count > 0)
                lstToDo.ItemsSource=data;
        }

        
        private void btnAddToDo_Click(object sender, RoutedEventArgs e)
        {
            spAddToDo.Visibility = Visibility.Visible;
            btnAddToDo.IsEnabled = false;
            btnDeleteToDo.IsEnabled = false;
            btnShowTasks.IsEnabled = false;
        }

        private void btnCreateToDo_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtToDoName.Text))
                MessageBox.Show("Please fill Name area!");
            else
            {
                toDoListModel.Name = txtToDoName.Text;
                toDoListModel.UserId = user.Id;
                toDoListModel.CreateDate = DateTime.Now;
                toDoListModel.UpdateDate = DateTime.Now;
                db.ToDoLists.Add(toDoListModel);
                db.SaveChanges();
                spAddToDo.Visibility = Visibility.Hidden;
                GetUser(user);
                MessageBox.Show("To-Do List added!");
                spAddToDo.Visibility = Visibility.Hidden;
                btnAddToDo.IsEnabled = true;
                btnDeleteToDo.IsEnabled = true;
                btnShowTasks.IsEnabled = true;
            }
        }

        private void btnDeleteToDo_Click(object sender, RoutedEventArgs e)
        {
            if(lstToDo.Items.Count == 0)
                MessageBox.Show("You don't have to-do for delete.");
            else if (lstToDo.SelectedItems.Count < 1)
                MessageBox.Show("Please select to-do(s) on list!");
            else
            {
                List<long> toListIds = new List<long>();
                foreach (object o in lstToDo.SelectedItems)
                {
                    toListIds.Add((o as ToDoList).Id);
                }
                var removeData = db.ToDoLists.Where(x => toListIds.Contains(x.Id)).ToList();
                db.ToDoLists.RemoveRange(removeData);
                db.SaveChanges();
                GetUser(user);
                MessageBox.Show("To-Do(s) deleted!");
            }
        }

        private void btnShowTasks_Click(object sender, RoutedEventArgs e)
        {
            var isValid = ValidList(lstToDo);
            if (isValid)
            {
                List<long> toListIds = new List<long>();
                foreach (object o in lstToDo.SelectedItems)
                {
                    toListIds.Add((o as ToDoList).Id);
                }
                var taskWindow = new TasksWindow();
                taskWindow.Show();
                taskWindow.GetData(user, toListIds);
                this.Close();
            }
        }

        public bool ValidList(ListView lstToDo)
        {
            if (lstToDo.Items.Count == 0)
            {
                MessageBox.Show("You don't have to-do for show task(s).");
                return false;
            }
            else if (lstToDo.SelectedItems.Count < 1)
            {
                MessageBox.Show("Please select to-do(s) for show task(s).");
                return false;
            }
            else if (lstToDo.SelectedItems.Count > 1)
            {
                MessageBox.Show("Please select only one to-do(s) for show task(s).");
                return false;
            }
            else
                return true;   
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            spAddToDo.Visibility = Visibility.Hidden;
            btnAddToDo.IsEnabled = true;
            btnDeleteToDo.IsEnabled = true;
            btnShowTasks.IsEnabled = true;
            GetUser(user);
        }
    }
}

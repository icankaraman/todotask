using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for TasksWindow.xaml
    /// </summary>
    public partial class TasksWindow : Window
    {
        List<ToDoTask> toDoTaskModel = new List<ToDoTask>();
        ToDoDbContext db = new ToDoDbContext();
        User userModel = new User();
        List<long> hasListIds;
        CollectionView view;
        GridViewColumnHeader _lastHeaderClicked = null;
        ListSortDirection _lastDirection = ListSortDirection.Ascending;

        public TasksWindow()
        {
            InitializeComponent();
        }
        public void GetData(User user, List<long> listId)
        {
            userModel = user;
            var data = db.ToDoTasks.AsQueryable().Where(x => x.UserId == user.Id && listId.Contains(x.ListId)).ToList();
           
            hasListIds = listId;
      
            if (data.Count > 0)
            {
                lstTasks.ItemsSource = data;
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lstTasks.ItemsSource);
                view.Filter = TaskFilter;
                cmbFilter.Text = "Name";
            }

        }

        public bool TaskFilter(object item)
        {
            if (String.IsNullOrEmpty(txtFilterValue.Text))
                return true;
            else if (cmbFilter.Text == "Name")
                return ((item as ToDoTask).Name.IndexOf(txtFilterValue.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            else         
                return ((item as ToDoTask).Description.IndexOf(txtFilterValue.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

     

        void GridViewColumnHeaderClickedHandler(object sender,
                                                RoutedEventArgs e)
        {
            var headerClicked = e.OriginalSource as GridViewColumnHeader;
            ListSortDirection direction;
            if (headerClicked != null)
            {
                if (headerClicked.Role != GridViewColumnHeaderRole.Padding)
                {
                    if (headerClicked != _lastHeaderClicked)
                    {
                        direction = ListSortDirection.Ascending;
                    }
                    else
                    {
                        if (_lastDirection == ListSortDirection.Ascending)
                        {
                            direction = ListSortDirection.Descending;
                        }
                        else
                        {
                            direction = ListSortDirection.Ascending;
                        }
                    }
                    var columnBinding = headerClicked.Column.DisplayMemberBinding as Binding;
                    var sortBy = columnBinding?.Path.Path ?? headerClicked.Column.Header as string;

                    Sort(sortBy, direction);

                    if (direction == ListSortDirection.Ascending)
                    {
                        headerClicked.Column.HeaderTemplate =
                          Resources["HeaderTemplateArrowUp"] as DataTemplate;
                    }
                    else
                    {
                        headerClicked.Column.HeaderTemplate =
                          Resources["HeaderTemplateArrowDown"] as DataTemplate;
                    }

                    if (_lastHeaderClicked != null && _lastHeaderClicked != headerClicked)
                    {
                        _lastHeaderClicked.Column.HeaderTemplate = null;
                    }

                    _lastHeaderClicked = headerClicked;
                    _lastDirection = direction;
                }
            }
        }

        private void Sort(string sortBy, ListSortDirection direction)
        {
            ICollectionView dataView =
              CollectionViewSource.GetDefaultView(lstTasks.ItemsSource);

            dataView.SortDescriptions.Clear();
            SortDescription sd = new SortDescription(sortBy, direction);
            dataView.SortDescriptions.Add(sd);
            dataView.Refresh();
        }

        private void btnBackToDo_Click(object sender, RoutedEventArgs e)
        {
            var listWindow = new ListWindow();
            listWindow.Show();
            listWindow.GetUser(userModel);
            this.Close();
        }

        private void btnAddTask_Click(object sender, RoutedEventArgs e)
        {
            var addTaskWindow = new AddTaskWindow();
            addTaskWindow.Show();
            addTaskWindow.GetUser(userModel,hasListIds);
            this.Close();
        }

        private void btnDeleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (lstTasks.Items.Count == 0)
                MessageBox.Show("You don't have task(s) for delete.");
            else if (lstTasks.SelectedItems.Count < 1)
                MessageBox.Show("Please select task(s) on list!");
            else
            {
                List<long> lstTaskIds = new List<long>();
                foreach (object o in lstTasks.SelectedItems)
                {
                    lstTaskIds.Add((o as ToDoTask).Id);
                }
                var removeData = db.ToDoTasks.Where(x => lstTaskIds.Contains(x.Id)).ToList();
                db.ToDoTasks.RemoveRange(removeData);
                db.SaveChanges();
                GetData(userModel,hasListIds);
                MessageBox.Show("Task(s) deleted!");
            }
        }

        private void txtFilterValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lstTasks.ItemsSource).Refresh();
        }

        private void btnUpdateTask_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
            GetData(userModel, hasListIds);
            MessageBox.Show("Task(s) updated!");
        }
    }
}

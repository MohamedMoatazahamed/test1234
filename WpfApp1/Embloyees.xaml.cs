using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Embloyees.xaml
    /// </summary>
    public partial class Embloyees : Page
    {
        MangesystemEntities db = new MangesystemEntities();

        public int emp;
        public Embloyees(int ido)
        {
        emp = ido;  
            InitializeComponent();
            show1();

        }
       

        public void show1()
        {

            var pendingTasks = db.Tasks123.Where(t => (t.userID == emp) && (t.status == "Pending" || t.status == "in progress"));
            var completedTasks = db.Tasks123.Where(t => (t.userID == emp) && (t.status == "completed"));
            db2.ItemsSource = pendingTasks.Select(s => new { s.TaskId, s.title,s.Descrption, s.status }).ToList();
            db1.ItemsSource = completedTasks.Select(s => new { s.TaskId, s.title, s.Descrption, s.status }).ToList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            int id = int.Parse(nio.Text);


            var selectedStatus = mon.SelectionBoxItem.ToString();
            var taskToUpdate = db.Tasks123.FirstOrDefault(t => t.TaskId == id);
            if (taskToUpdate != null)
            {
                taskToUpdate.status = selectedStatus;

                db.Tasks123.AddOrUpdate(taskToUpdate);
                db.SaveChanges();
                show1();
            }
            else
            {
                MessageBox.Show("Task not found. Error.");
            }
        }
    }
}


     


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
using System.Security.Cryptography;
using System.Xml.Linq;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        MangesystemEntities mo = new MangesystemEntities();
        public Admin()
        {
            InitializeComponent();
            Show();

        }
        public void Show()
        {
            gride.ItemsSource = mo.Tasks123.Select(s => new { s.TaskId, s.title, s.Descrption, s.status, s.usertable123.Email }).ToList();
        }







        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            var combo = n.SelectionBoxItem.ToString();
            usertable123 u1 = mo.usertable123.FirstOrDefault(x => x.Email == name.Text);
            if (u1 != null)
            {
                Tasks123 task = new Tasks123();

                task.title = title.Text;
                task.Descrption = Des.Text;
                task.status = combo;


                u1.Tasks123.Add(task);
                MessageBox.Show("date save");
                mo.SaveChanges();
                Show();


            }
            else
            {
                MessageBox.Show("date not save");
            }

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var combo = n.SelectionBoxItem.ToString();

            Tasks123 t1 = new Tasks123();
            int id = int.Parse(id1.Text);
            t1 = mo.Tasks123.FirstOrDefault(x => x.TaskId == id);
            if (t1 != null)
            {

                t1.title = title.Text;
                t1.Descrption = Des.Text;
                t1.status = combo;

                mo.Tasks123.AddOrUpdate(t1);
                mo.SaveChanges();
                Show();
            }
            else
            {
                MessageBox.Show("no apdate");
            }

        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {

            Tasks123 t1 = new Tasks123();
            int id = int.Parse(id1.Text);
            var ema = mo.Tasks123.FirstOrDefault(x => x.TaskId == id);
            if (ema != null)
            {
                mo.Tasks123.Remove(ema);
                mo.SaveChanges();
                Show();
            }
            else
            {
                MessageBox.Show("no delete");
            }
        }

        private void Button_Click5(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(id1.Text);
            gride.ItemsSource = mo.Tasks123.Where(x => x.TaskId == id).Select(s => new { s.TaskId, s.title, s.Descrption, s.status, s.usertable123.Email }).ToList();


          
       
            
        }
    }
}
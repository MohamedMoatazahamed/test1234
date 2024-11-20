using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class Login : Page
    {
          MangesystemEntities db=new MangesystemEntities();

            public Login()
            {
                InitializeComponent();
            }

            private void Button_Click(object sender, RoutedEventArgs e)
            {
                var search = db.usertable123.FirstOrDefault(x => x.Email == email.Text && x.password == pass.Text);
                if (search != null)
                {

                    if (search.role == "Manager")
                    {
                     Admin admin = new Admin(); 
                        this.NavigationService.Navigate(admin);

                    }
                    else
                    {
                   Embloyees embloyees = new Embloyees(search.userID);
                        this.NavigationService.Navigate(embloyees);
                    }

                }
            else
            {
                MessageBox.Show("not email and password");
            }

            }
        
    }
}
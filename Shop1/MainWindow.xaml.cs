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
using System.Windows.Navigation;
using System.Windows.Shapes;

using Shop1.Windows;

namespace Shop1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
        }
        // Обработчик кнопки ВОЙТИ.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = loginElem.Text;
            string password = passwordElem.Password;

            User user = Helpers.Auth(login, password);

            if (user == null) 
            {
                return;
            }

            Store.user = user;

            if (user.UserRole == 1)
            {
                new Admin().Show();
                Close();
            }
            else
            {
                new Manager().Show();
                Close();
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new Guest().Show();
            Close();
        }
    }
}

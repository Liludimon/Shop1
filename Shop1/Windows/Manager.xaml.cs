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

namespace Shop1.Windows
{
    /// <summary>
    /// Логика взаимодействия для Manager.xaml
    /// </summary>
    public partial class Manager : Window
    {
        private User user = Store.user;
        public Manager()
        {
            InitializeComponent();

            //ФИО клиента/менеджера в углу экрана
            fioElem.Content = $"{user.UserSurname} {user.UserName} {user.UserPatronymic}";

            //Вывод таблицы на экран
            productElem.ItemsSource = Helpers.connection.Product.ToList();

            //Заполняем комбобокс производителями
            List<string> manuf = new List<string>();

            manuf.Add("Все производители");
            manuf.AddRange(Helpers.connection.Product.Select(x => x.ProductManufacturer).Distinct().ToList());

            filtrElem.ItemsSource = manuf;
        }
        //Кнопка Выйти
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Store.user = null;

            new MainWindow().Show();
            Close();
        }

        //Поиск товара по наименованию
        private void findElem_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Product> products = Helpers.connection.Product.Where(x => x.ProductName.Contains(findElem.Text)).ToList();
            productElem.ItemsSource = products;
        }
       
        //Кнопка Фильтрация
        private void filtrElem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string manuf = filtrElem.SelectedItem.ToString();
            List<Product> products = new List<Product>();
            if (manuf == "Все производители")
            {
                products = Helpers.connection.Product.ToList();
            }
            else
            {
                products = Helpers.connection.Product.Where(x => x.ProductManufacturer == manuf).ToList();
            }

            productElem.ItemsSource = products;
        }
    }
}

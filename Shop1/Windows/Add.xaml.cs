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
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        
        public Add()
        {
            InitializeComponent();
        }

        //Сохранение добавленного товара
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Product current = Helpers.connection.Product.FirstOrDefault(x => x.ProductArticleNumber == articlElem.Text);

            if (current != null)
            {
                MessageBox.Show("Товар с таким артикулом уже существует");
                return;
            }

            ComboBoxItem item = (ComboBoxItem)categorElem.SelectedItem;

            Product product = new Product();
            product.ProductArticleNumber = articlElem.Text;
            product.ProductName = productnameElem.Text;
            product.ProductDescription = descripElem.Text;
            product.ProductManufacturer = manufElem.Text;
            product.ProductCost = int.Parse(costElem.Text);  
            product.ProductCategory = item.Content.ToString();
            product.ProductDiscountAmount = int.Parse(discountElem.Text);
            product.ProductQuantityInStock = int.Parse(quantElem.Text);


            Helpers.connection.Product.Add(product);
            Helpers.connection.SaveChanges();

            MessageBox.Show("Товар добавлен!");
            new Admin().Show();
            Close();
        }
    }
}

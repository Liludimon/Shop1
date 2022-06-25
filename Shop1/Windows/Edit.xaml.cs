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
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    /// Кнопка Редактировать
    public partial class Edit : Window
    {
        public Edit(Product _product)
        {
            InitializeComponent();

            articlElem.Text = _product.ProductArticleNumber;
            productnameElem.Text = _product.ProductName;
            descripElem.Text = _product.ProductDescription;
            manufElem.Text = _product.ProductManufacturer;
            costElem.Text = _product.ProductCost.ToString();
            discountElem.Text = _product.ProductDiscountAmount.ToString();
            quantElem.Text = _product.ProductQuantityInStock.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)categorElem.SelectedItem;

            string articl = articlElem.Text;
            string productname = productnameElem.Text;
            string descrip = descripElem.Text;
            string manuf = manufElem.Text;
            string category = item.Content.ToString();
            int cost = int.Parse(costElem.Text);
            int quant = int.Parse(quantElem.Text);
            int discount = int.Parse(discountElem.Text);

            Product edidProduct = Helpers.connection.Product.FirstOrDefault(x => x.ProductArticleNumber == articl);

            edidProduct.ProductArticleNumber = articl;
            edidProduct.ProductName = productname;
            edidProduct.ProductDescription = descrip;
            edidProduct.ProductManufacturer = manuf;
            edidProduct.ProductCost = cost;
            edidProduct.ProductQuantityInStock = quant;
            edidProduct.ProductDiscountAmount = discount;
            edidProduct.ProductCategory = category;

            Helpers.connection.SaveChanges();
            MessageBox.Show("Товар отредактирован!");
            new Admin().Show();
            Close();
        }
    }
}

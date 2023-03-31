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

namespace ProductApps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Product cProduct;

        public MainWindow()
        {
            InitializeComponent();
        }

        private decimal GST = 1.10m;

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                cProduct = new Product(Convert.ToDecimal(priceTextBox.Text), Convert.ToInt16(quantityTextBox.Text));
                cProduct.calTotalPayment();
                totalPaymentTextBlock.Text = Convert.ToString(cProduct.TotalPayment);

                //Calc total charge after adding shipping cost
                totalChargeTextBox.Text = (cProduct.TotalPayment + 25).ToString("C");

                //Calc total charge after adding wrap cost & shipping cost
                totalChargeAfterWrapTextBox.Text = (cProduct.TotalPayment + 25 + 5).ToString("C");

                //Calc total charge after adding wrap cost & shipping cost + GST @10%
                decimal totalCharge = cProduct.TotalPayment + 25 + 5;

                totalChargeAfterGSTTextBox.Text = (totalCharge * GST).ToString("C");
            }
            catch (FormatException)
            {
                MessageBox.Show("Enter data again", "Data Entry Error");
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            productTextBox.Text = "";
            priceTextBox.Text = "";
            quantityTextBox.Text = "";
            totalPaymentTextBlock.Text = "";
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

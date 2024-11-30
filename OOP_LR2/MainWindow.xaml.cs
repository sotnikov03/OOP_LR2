using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace OOP_LR2
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int cups = CupsUpDown.Value ?? 1; // 

                
                if (CoffeeTypeComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Пожалуйста, выберите тип кофе.");
                    return;
                }

                string coffeeType = ((ComboBoxItem)CoffeeTypeComboBox.SelectedItem).Content.ToString();
                bool hasSugar = SugarCheckBox.IsChecked ?? false;
                bool hasCream = CreamCheckBox.IsChecked ?? false;

                double cost = 0;

                switch (coffeeType)
                {
                    case "Эспрессо":
                        cost = cups * 110;
                        break;
                    case "Латте":
                        cost = cups * 120;
                        break;
                    case "Капучино":
                        cost = cups * 130;
                        break;
                }

                if (hasSugar)
                    cost += cups * 10;

                if (hasCream)
                    cost += cups * 15;

                CultureInfo culture = new CultureInfo("ru-RU");
                ResultTextBlock.Text = $"Стоимость: {cost.ToString("C", culture)}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка ввода данных. Пожалуйста, проверьте введенные данные.");
            }
        }
    }
}

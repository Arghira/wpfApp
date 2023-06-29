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
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary> 
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        SelectedOperator selectedOperator;
        public MainWindow()
        {
            InitializeComponent();

            acButton.Click += AcButton_Click;
            negativeButton.Click += NegativeButton_Click;
            percentButton.Click += PercentButton_Click;
            equalButton.Click += EqualButton_Click;
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {

            if (double.TryParse(resultLabel.Content.ToString(), out double newNumber))
            {
                switch(selectedOperator) 
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Subtraction:
                        result = SimpleMath.Subtract(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiplication(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Division(lastNumber, newNumber);
                        break;
                }

                resultLabel.Content = result.ToString();
            }

        }

        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out double tempNumber))
            {
                tempNumber /= 100;
                if (lastNumber != 0)
                    tempNumber *= lastNumber;
                resultLabel.Content = tempNumber.ToString();
            }
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }

        private void OperationButton(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = "0";
            }

            if (sender == multiplyButton)
                selectedOperator = SelectedOperator.Multiplication;
            if (sender == divisionButton)
                selectedOperator = SelectedOperator.Division;
            if (sender == plusButton)
                selectedOperator = SelectedOperator.Addition;
            if (sender == minusButton)
                selectedOperator = SelectedOperator.Subtraction;
        }

        private void dotButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString().Contains("."))
            {
                //Do nothing
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}.";
            }
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = int.Parse((sender as Button).Content.ToString());

            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = $"{selectedValue}";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}{selectedValue}";
            }

        }
    }
    public enum SelectedOperator
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

    public class SimpleMath
    {
        public static double Add(double n1, double n2)
        {
            return n1 + n2;
        }

        public static double Subtract(double n1, double n2)
        {
            return n1 - n2;
        }

        public static double Multiplication(double n1, double n2)
        {
            return n1 * n2;
        }

        public static double Division(double n1, double n2) 
        {
            if(n2 == 0)
            {
                MessageBox.Show("Blah Blah not supported", "Div by 0 lmao", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
            return n1 / n2;
        }
    }
}

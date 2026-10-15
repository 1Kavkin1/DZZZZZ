using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace DZ
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double _accumulator = 0;
        private string _pendingOp = null;
        private bool _isNewEntry = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Digit and dot buttons
        private void Button_Digital_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            string value = (button.Content ?? string.Empty).ToString();

            if (_isNewEntry)
            {
                CalcDisplay.Text = "";
                _isNewEntry = false;
            }

            if (value == ".")
            {
                if (!CalcDisplay.Text.Contains(".")) CalcDisplay.Text += ".";
            }
            else
            {
                CalcDisplay.Text += value;
            }
        }

        // Operator buttons (+ - * /)
        private void Button_Operator_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            string op = (button.Content ?? string.Empty).ToString();

            if (double.TryParse(CalcDisplay.Text, out double val))
            {
                if (_pendingOp == null)
                {
                    _accumulator = val;
                }
                else
                {
                    _accumulator = Evaluate(_accumulator, val, _pendingOp);
                    CalcDisplay.Text = _accumulator.ToString();
                }
            }

            _pendingOp = op;
            _isNewEntry = true;
        }

        private void Button_Equals_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(CalcDisplay.Text, out double val) && _pendingOp != null)
            {
                _accumulator = Evaluate(_accumulator, val, _pendingOp);
                CalcDisplay.Text = _accumulator.ToString();
                _pendingOp = null;
                _isNewEntry = true;
            }
        }

        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            CalcDisplay.Text = "";
            _accumulator = 0;
            _pendingOp = null;
            _isNewEntry = true;
        }

        // Простий заповнювач для дужок (парсер виразів не реалізовано)
        private void Button_Paren_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Дужки — лише заповнювач у цьому простому калькуляторі.", "Інфо", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private double Evaluate(double left, double right, string op)
        {
            return op switch
            {
                "+" => left + right,
                "-" => left - right,
                "*" => left * right,
                "/" => right == 0 ? double.NaN : left / right,
                _ => right,
            };
        }

        // Demo buttons
        private void BtnShapes_Click(object sender, RoutedEventArgs e)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Демо: фігури");

            try
            {
                var c = new Models.Circle(3);
                var r = new Models.Rectangle(4, 5);
                var t = new Models.Triangle(3, 4, 5);

                sb.AppendLine($"Коло (r=3) площа = {c.GetArea():F2}");
                sb.AppendLine($"Прямокутник (4x5) площа = {r.GetArea():F2}");
                sb.AppendLine($"Трикутник (3,4,5) площа = {t.GetArea():F2}");

                // демонстрація оператора 'is'
                sb.AppendLine($"c є Shape: { (c is Models.Shape) }");
                sb.AppendLine($"r є Triangle: { (r is Models.Triangle) }");
            }
            catch (Exception ex)
            {
                sb.AppendLine("Помилка: " + ex.Message);
            }

            OutputBox.Text = sb.ToString();
        }

        private void BtnExceptions_Click(object sender, RoutedEventArgs e)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Демо: власні виключення");

            try
            {
                // спроба створити некоректне коло
                var bad = new Models.Circle(-1);
            }
            catch (Exceptions.InvalidShapeException ex)
            {
                sb.AppendLine("Перехоплено InvalidShapeException: " + ex.Message);
            }
            catch (Exception ex)
            {
                sb.AppendLine("Перехоплено загальне виключення: " + ex.Message);
            }

            OutputBox.Text = sb.ToString();
        }

        private void BtnShelter_Click(object sender, RoutedEventArgs e)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Демо: притулок");

            var shelter = new Shelter.MyShelter<Animals.Animal>();
            var dog1 = new Animals.Dog("Rex");
            var dog2 = new Animals.Dog("Rex");
            var cat1 = new Animals.Cat("Murka");

            shelter.Add(dog1);
            shelter.Add(cat1);

            sb.AppendLine($"У притулку {shelter.Count} тварин");
            sb.AppendLine($"dog1 == dog2 ? { (dog1 == dog2) }");
            sb.AppendLine($"dog1 != dog2 ? { (dog1 != dog2) }");

            OutputBox.Text = sb.ToString();
        }
    }
}

using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WPFApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Установка изображения программно (на случай, если путь абсолютный)
            // FunctionImage.Source = new BitmapImage(new Uri(@"C:\Users\armanizxc\source\repos\422_Pluzhnikov_Egunov\422_Pluzhnikov_Egunov\Img\Без имени.png"));
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Считываем вводимые значения
                double x = double.Parse(InputX.Text);
                double m = double.Parse(InputM.Text);

                // Вычисляем значение f(x) в зависимости от выбора пользователя
                double fx = 0;
                if (FunctionSh.IsChecked == true)
                {
                    fx = Math.Sinh(x); // sh(x)
                }
                else if (FunctionSin.IsChecked == true)
                {
                    fx = Math.Sin(x); // sin(x)
                }
                else if (FunctionCos.IsChecked == true)
                {
                    fx = Math.Cos(x); // cos(x)
                }

                // Вычисляем j по заданной формуле
                double j = 0;
                if (m < x && x > -1)
                {
                    j = Math.Sin(5 * fx + 3 * m * Math.Abs(fx));
                }
                else if (x > m)
                {
                    j = Math.Cos(3 * fx + 5 * m * Math.Abs(fx));
                }
                else if (x == m)
                {
                    j = Math.Pow(fx + m, 2);
                }

                // Выводим результат
                ResultOutput.Text = j.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            // Очищаем все поля
            InputX.Clear();
            InputM.Clear();
            ResultOutput.Clear();
            FunctionSh.IsChecked = false;
            FunctionSin.IsChecked = false;
            FunctionCos.IsChecked = false;
        }
    }
}

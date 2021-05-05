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

namespace HomeWork_db
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string pass = PasswordBox1.Password.Trim();
            string loign = TextBoxLogin.Text.Trim();
            string passbox = TextBoxPassword.Text.Trim();

            //if (loign.Length < 5)
            //{
            //    MessageBox.Show("Проверьте правильность ввода", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
            //}

            //else if (pass.Length < 5)
            //{
            //    MessageBox.Show("Проверьте правильность ввода", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
            //}

            //else if (passbox.Length < 5)
            //{
            //    MessageBox.Show("Проверьте правильность ввода", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
            //}

            //if (TextBoxLogin.Text == null || (PasswordBox1.Password == null || TextBoxPassword.Text == null))
            //{
            //    MessageBox.Show("ошибка", "Заполните поля", MessageBoxButton.OK, MessageBoxImage.Error);
            //}

            //if
            //{
                User authUser = null;
                using (TestMagazineEntities db = new TestMagazineEntities())
                {
                    authUser = db.User.Where(us => us.Login == loign && (us.Password == passbox || us.Password == pass)).FirstOrDefault();
                }
                if (authUser != null)
                {
                    WinMain2 winmain = new WinMain2();
                    winmain.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Проверьте правильность ввода", "Ой-ой", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            //}
            //WinMain2 main = new WinMain2();
            //main.Show();
            //Hide();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            TextBoxPassword.Text = PasswordBox1.Password;

            TextBoxPassword.Visibility = Visibility.Visible;
            PasswordBox1.Visibility = Visibility.Hidden;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            PasswordBox1.Password = TextBoxPassword.Text;

            TextBoxPassword.Visibility = Visibility.Hidden;
            PasswordBox1.Visibility = Visibility.Visible;
        }
    }
}

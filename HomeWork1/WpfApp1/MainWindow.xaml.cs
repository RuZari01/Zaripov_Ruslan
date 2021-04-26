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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int role;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            if (TextBoxLogin.Text == "login" && (PasswordBox1.Password == "tuptup" || TextBoxPassword.Text == "tuptup"))
            {         
                role = 0;
                LoginIn LohinIn = new LoginIn(role);
                LohinIn.Show();
            }
            if (TextBoxLogin.Text == "login2" && (PasswordBox1.Password == "2222" || TextBoxPassword.Text == "2222"))
            {
                role = 1;
                LoginIn LohinIn = new LoginIn(role);
                LohinIn.Show();
            }
            else
            {
                MessageBox.Show("Проверьте правильность ввода", "ОшибкаПроверьте правильность ввода", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public void ErrorCheck()
        {
            if(TextBoxLogin.Text == "" || (PasswordBox1.Password == "" || TextBoxPassword.Text == ""))
            {
                MessageBox.Show("ошибка","Заполните поля", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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

        private void TextBoxLogin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

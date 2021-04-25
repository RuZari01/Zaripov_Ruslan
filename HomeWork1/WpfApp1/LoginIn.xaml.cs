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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для LoginIn.xaml
    /// </summary>
    public partial class LoginIn : Window
    {
        int RoleId;
        public LoginIn(int _role)
        {
            InitializeComponent();
            RoleId = _role;
            Date();
        }

        public void Date()
        {
            switch (RoleId)
            {
                case 0:
                    LabelName.Content = "Виталий";
                    LabelLastName.Content = "Колчук";
                    LabelRole.Content = "Менеджер";
                    break;
                case 1:
                    LabelName.Content = "Константин";
                    LabelLastName.Content = "Горин";
                    LabelRole.Content = "Админ";
                    PhotoProfile.Source = new BitmapImage(new Uri(@"pack://application:,,,/images/cat.png"));
                    break;
            }
        }

        private void BtnAddSales_Click(object sender, RoutedEventArgs e)
        {
            var AddSale = new AddSale();
            AddSale.Show();
        }
    }
}

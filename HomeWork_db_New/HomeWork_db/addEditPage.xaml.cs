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
    /// Логика взаимодействия для addEditPage.xaml
    /// </summary>
    public partial class addEditPage : Page
    {

        private User _newUser = new User();

        public addEditPage(User selUser)
        {
            InitializeComponent();

            if (selUser != null)
                _newUser = selUser;

            DataContext = _newUser;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_newUser.LastName))
                errors.AppendLine("поле Фамилия");

            if (string.IsNullOrWhiteSpace(_newUser.FirstName))
                errors.AppendLine("поле Имя");

            if (string.IsNullOrWhiteSpace(_newUser.Login))
                errors.AppendLine("поле Имя");

            if (string.IsNullOrWhiteSpace(_newUser.Password))
                errors.AppendLine("поле Имя");

            if (errors.Length > 0)
            {
                MessageBox.Show($"Заполните {errors.ToString()}", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (_newUser.id == 0)
                TestMagazineEntities.GetContext().User.Add(_newUser);

            try
            {
                TestMagazineEntities.GetContext().SaveChanges();
                MessageBox.Show("Успех", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}

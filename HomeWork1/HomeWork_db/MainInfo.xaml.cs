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
    /// Логика взаимодействия для MainInfo.xaml
    /// </summary>
    public partial class MainInfo : Page
    {
        public MainInfo()
        {
            InitializeComponent();

        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new addEditPage(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                TestMagazineEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DataGridMagazine.ItemsSource = TestMagazineEntities.GetContext().User.ToList();
            }
        }

        private void Btnedit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new addEditPage((sender as Button).DataContext as User));
        }

        private void Button_Click_Del(object sender, RoutedEventArgs e)
        {
            var userForDel = DataGridMagazine.SelectedItems.Cast<User>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить {userForDel.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes);
            try
            {
                TestMagazineEntities.GetContext().User.RemoveRange(userForDel);
                TestMagazineEntities.GetContext().SaveChanges();
                MessageBox.Show("Успех", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                DataGridMagazine.ItemsSource = TestMagazineEntities.GetContext().User.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Button_Click_Main(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
        }
    }
}

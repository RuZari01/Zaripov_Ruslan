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

namespace HomeWork_db
{
    /// <summary>
    /// Логика взаимодействия для WinMain2.xaml
    /// </summary>
    public partial class WinMain2 : Window
    {
        public WinMain2()
        {
            InitializeComponent();
            MainFrame.Navigate(new MainInfo());
            Manager.MainFrame = MainFrame;
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {

        }
    }
}

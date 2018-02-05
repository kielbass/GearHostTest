using GearHostTest.Models;
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

namespace GearHostTest.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy Autorization.xaml
    /// </summary>
    public partial class Autorization : Window
    {
        private User _user;
        internal Autorization(ref User user)
        {
            InitializeComponent();
            _user = user;
        }

        private void btnExe_Click(object sender, RoutedEventArgs e)
        {
            _user.Pass = txtPass.Password;
            if(int.TryParse(txtName.Text,out int a))
            {
                _user.ID = a;
            }
            else
            {
                _user.Name = txtName.Text;
            }
            this.Close();
        }
    }
}

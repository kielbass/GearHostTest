using GearHostTest.Classes;
using GearHostTest.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Net.Http;


namespace GearHostTest
{

    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Query _query;
        private User _user;
        private ObservableCollection<Message> _messages;
        public MainWindow()
        {
            Initialize();
            InitializeComponent();

            lstMessages.ItemsSource = _messages;
            Refresh();

        }
    

        private void Initialize()
        {
            User temp = new User();
            
            _query = new Query();
            do
            {
              Windows.Autorization win = new Windows.Autorization(ref temp);
              win.ShowDialog();
            } while (!_query.Authorization(temp));
            _user = _query.GetUser(temp.ID);
            _messages = new ObservableCollection<Message>(_query.Db.Messages.OrderByDescending(x => x.ID));
            
            _query.Close();

        }
        private void Refresh()
        {
            _query = new Query();
            txtGreetings.Text = string.Format("Greetings {0}!", _user.Name);
            _messages.Clear();
            _messages = new ObservableCollection<Message>(_query.Db.Messages.OrderByDescending(x => x.ID));
            foreach(Message m in _messages)
            {

                m.User =  _query.GetUser(m.UserID);
                m.UserID = m.UserID;
            }
            lstMessages.ItemsSource = _messages;
            lstMessages.Items.Refresh();
            _query.Close();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            _query = new Query();
            Message message = new Message()
            {
                Text = txtMessage.Text,
                User = _query.GetUser(_user.ID),
                UserID = _user.ID
            };
            _query.AddMessage(message);
            Refresh();
            txtMessage.Text = "";
            _query.Close();
        }
    }
}

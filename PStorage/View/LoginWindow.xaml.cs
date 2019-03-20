using PStorage.Helper;
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

namespace PStorage.View
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            DBHelper.EstablishConnection();
        }
        
        /// <summary>
        /// Проверка пароля и логина с БД по методу RetrieveUser.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbOk_Click(object sender, RoutedEventArgs e)
        {
            string username = tb_Login.Text;
            string password = tb_Password.Password;

            Users aUser = UsersDA.RetrieveUser(username);

            try
            {
                if (aUser.Password.Equals(password))
                {
                    MessageBox.Show("login Success");
                    View.MainWindow mw = new MainWindow();
                    mw.Show();
                }
                else
                {
                    lb_message.Content = "Неверный пароль.";
                    tb_Password.Password = "";
                }
            }
            catch (Exception)
            {
                lb_message.Content = "Неверный логин:";
                tb_Login.Text = "";
            }
        }

        private void TbExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}


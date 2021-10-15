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

namespace BS
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Model1 db = new Model1();

        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow.AUTOR.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TBLog.Text == "" || TBPass.Text == "" || TBPass1.Text == "" || TBName.Text == ""||CBRole.Text=="")
            {
                MessageBox.Show("Задайте все данные");
                return;
            }
            if (TBPass.Text != TBPass1.Text)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }
            Пользователи usr = db.Пользователи.Find(TBLog.Text);
            if (usr != null)
            {
                MessageBox.Show("Пользователь с таким логином уже существует");
                return;
            }
            usr = new Пользователи();
            usr.Логин = TBLog.Text;
            usr.Пароль = TBPass.Text;
            usr.Роль = CBRole.Text;
            usr.Имя = TBName.Text;
            db.Пользователи.Add(usr);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            MessageBox.Show("Пользователь " + usr.Логин + " зарегистрирован");
            MainWindow.AUTOR.Show();
            this.Close();
            return;
        }

        private void CBRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

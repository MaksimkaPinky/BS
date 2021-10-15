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

namespace BS
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Model1 db = new Model1();
        Пользователи USER { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            
        }
        public static MainWindow AUTOR { get; set; }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TBLog.Text == "" || TBPass.Text == "")
            {
                MessageBox.Show("Заполните поля");
                return;
            }
            Пользователи usr = db.Пользователи.Find(TBLog.Text);
            if ((usr != null) && (usr.Пароль == TBPass.Text))
            {
                USER = usr;
                AUTOR = this;
            }
            if(usr.Роль=="Администратор")
            {
                Window2 ADM = new Window2();
                ADM.Show();
                this.Hide();
            }
            if (usr.Роль == "Менеджер")
            {
                Window3 MAN = new Window3();
                MAN.Show();
                this.Hide();
            }
            if (usr.Роль == "Пользователь")
            {
                Window4 USE = new Window4();
                USE.Show();
                this.Hide();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window1 Reg = new Window1();
            AUTOR = this;
            this.Hide();
            Reg.Show();
        }
    }
}

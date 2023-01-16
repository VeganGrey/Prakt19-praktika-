using PrimerBD;
using PrimerBTN;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Threading;
using System.Windows.Threading;

namespace Prakt18_praktika_
{
    /// <summary>
    /// Логика взаимодействия для PasswordWindow.xaml
    /// </summary>
    public partial class PasswordWindow : Window
    {
        public PasswordWindow()
        {
            InitializeComponent();
        }
        DispatcherTimer _timer;
        int _countLogin = 1;
        DetdomEntities db = DetdomEntities.GetContext();
        DateTime time1 = new DateTime(3000, 12, 12);

        void Captcha()
        {
            string masChar = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm" +
                "1234567890/_-";
            string captcha = "";
            Random rnd = new Random();
            for (int i = 1; i <= 4; i++)
            {
                captcha = captcha + masChar[rnd.Next(0, masChar.Length)];
            }
            grib.Visibility = Visibility.Visible;
            txtCaptcha.Text = captcha;
            tbCaptcha.Text = null;
            txtCaptcha.LayoutTransform = new RotateTransform(rnd.Next(-15, 15));
            line.X1 = 10;
            line.X2 = 280;
            line.Y1 = rnd.Next(10, 40);
            line.Y2 = rnd.Next(10, 40);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbLogin.Focus();
            DataBtn.Login = false;
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 0,1);
            _timer.Tick += new EventHandler(timer_Tick);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            if (time == time1)
            {
                stackpanel.IsEnabled = true;
                _timer.Stop();
            }
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            var user = from p in db.Users
                       where p.UserLogin == tbLogin.Text && p.UserPassword == tbPas.Password
                       select p;
            if (user.Count() == 1 && txtCaptcha.Text == tbCaptcha.Text)
            {
                DataBtn.Login = true;
                DataBtn.Familia = user.First().UserSurname;
                DataBtn.Name = user.First().UserName;
                DataBtn.Otchestvo = user.First().UserPatronymic;
                DataBtn.Right = user.First().Role.RoleName;
                Close();
            }
            else
            {
                if (user.Count() == 1)
                {
                    MessageBox.Show("Captcha неверна,повторите ввод заново");
                }
                else
                {
                    MessageBox.Show("Логин,пароль неверны! Повторите ввод.");
                }
                Captcha();
                if (_countLogin >= 2)
                {
                    stackpanel.IsEnabled = false;
                    _timer.Start();
                    MessageBox.Show($"Пароль и логин неверные.Аха ха ха,Увидимся в {time1.ToString("dd:HH:yyyy")} ;)");
                }
                _countLogin++;
                tbLogin.Focus();
            }
        }

        private void btnEsc_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnGuest_Click(object sender, RoutedEventArgs e)
        {
            DataBtn.Login = true;
            DataBtn.Familia = "Гость";
            DataBtn.Name = "";
            DataBtn.Otchestvo = "";
            DataBtn.Right = "Клиент";
            Close();
        }
    }
}

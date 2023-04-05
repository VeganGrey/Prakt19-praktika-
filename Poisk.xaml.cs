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
using System.Windows.Shapes;
using PrimerBTS;

namespace Prakt18_praktika_
{
    /// <summary>
    /// Логика взаимодействия для Poisk.xaml
    /// </summary>
    public partial class Poisk : Window
    {
        public Poisk()
        {
            InitializeComponent();
        }

        DetDomContext db = DetDomContext.GetContext();

        private void R2_Checked(object sender, RoutedEventArgs e)
        {
            Radius2.IsEnabled = true;
            Radius1.IsEnabled = false;
            Radius3.IsEnabled = false;
            Radius4.IsEnabled = false;
            Radius5.IsEnabled = false;
        }

        private void R3_Checked(object sender, RoutedEventArgs e)
        {
            Radius3.IsEnabled = true;
            Radius1.IsEnabled = false;
            Radius2.IsEnabled = false;
            Radius4.IsEnabled = false;
            Radius5.IsEnabled = false;
        }

        private void R4_Checked(object sender, RoutedEventArgs e)
        {
            Radius4.IsEnabled = true;
            Radius1.IsEnabled = false;
            Radius2.IsEnabled = false;
            Radius3.IsEnabled = false;
            Radius5.IsEnabled = false;
        }

        private void R5_Checked(object sender, RoutedEventArgs e)
        {
            Radius5.IsEnabled = true;
            Radius1.IsEnabled = false;
            Radius2.IsEnabled = false;
            Radius3.IsEnabled = false;
            Radius4.IsEnabled = false;
        }

        private void R1_Checked(object sender, RoutedEventArgs e)
        {
            Radius1.IsEnabled = true;
            Radius5.IsEnabled = false;
            Radius2.IsEnabled = false;
            Radius3.IsEnabled = false;
            Radius4.IsEnabled = false;
        }

        private void Qiut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            if (R1.IsChecked == true)
            {
                Int32.TryParse(Zena.Text,out int zen);
                db.Toys.Load();
                var pen = from p in db.Toys
                        where p.Price == zen
                        select p;
                DataBasic.bs = (Toy)pen;
            }
            if (R2.IsChecked == true)
            {
                db.Toys.Load();
                var pen = from p in db.Toys
                          where p.Name == Name.Text
                          select p;
                DataBasic.bs = (Toy)pen;
            }
            if (R3.IsChecked == true)
            {
                Int32.TryParse(Kol.Text, out int kol);
                db.Toys.Load();
                var pen = from p in db.Toys
                          where p.Price == kol
                          select p;
                DataBasic.bs = (Toy)pen;
            }
            if (R4.IsChecked == true)
            {
                db.Toys.Load();
                var pen = from p in db.Toys
                          where p.FactoryName == Factory.Text
                          select p;
                DataBasic.bs = (Toy)pen;
            }
            if (R5.IsChecked == true)
            {
                Int32.TryParse(Zena.Text, out int zen);
                db.Toys.Load();
                var pen = from p in db.Toys
                          where p.CityFactory == Factory.Text
                          select p;
                DataBasic.bs = (Toy)pen;
            }
            MessageBox.Show("Выборка применена","Информация",MessageBoxButton.OK);
            this.Close();
        }
    }
}

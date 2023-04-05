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

namespace Prakt18_praktika_
{
    /// <summary>
    /// Логика взаимодействия для DeleteFilter.xaml
    /// </summary>
    public partial class DeleteFilter : Window
    {
        public DeleteFilter()
        {
            InitializeComponent();
        }
        DetDomContext db = DetDomContext.GetContext();
        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void R1_Checked(object sender, RoutedEventArgs e)
        {
            Radius1.IsEnabled = true;
            Radius2.IsEnabled = false;
        }

        private void R2_Checked(object sender, RoutedEventArgs e)
        {
            Radius1.IsEnabled = false;
            Radius2.IsEnabled = true;
        }

        private void DeleteFilter_Click(object sender, RoutedEventArgs e)
        {
            if (R1.IsChecked == true)
            {
                Int32.TryParse(Zena.Text,out int zena);
                int numberDel = db.Database.ExecuteSqlCommand($"DELETE FROM Toy Where Kol={zena}");
            }
            if (R2.IsChecked == true)
            {
                Int32.TryParse(Kol.Text,out int kol);
                int numberDel = db.Database.ExecuteSqlCommand($"DELETE FROM Toy Where Kol={kol}");
            }
            MessageBox.Show("Удалено");
            this.Close();
        }
    }
}

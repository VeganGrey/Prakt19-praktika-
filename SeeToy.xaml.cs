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
using PrimerBD;

namespace Prakt18_praktika_
{
    /// <summary>
    /// Логика взаимодействия для SeeToy.xaml
    /// </summary>
    public partial class SeeToy : Window
    {
        public SeeToy()
        {
            InitializeComponent();
        }
        DetdomEntities db = DetdomEntities.GetContext();
        Toy toy;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            toy = db.Toys.Find(Data.Id);
            NameToy.Text = toy.Name;
            Price.Text = Convert.ToString(toy.Price);
            Kol.Text = Convert.ToString(toy.Kol);
            AgeCategory.Text = Convert.ToString(toy.AgeCategory);
            FactoryName.Text = toy.FactoryName;
            CityFactory.Text = toy.CityFactory;
        }

        private void Quit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

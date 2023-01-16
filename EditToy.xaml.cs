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
    /// Логика взаимодействия для EditToy.xaml
    /// </summary>
    public partial class EditToy : Window
    {
        public EditToy()
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
        private void EditToy_Button(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (NameToy.Text.Length == 0) errors.AppendLine("Введите название");
            if (Price.Text.Length == 0 || Int32.TryParse(Price.Text, out int price) == false) errors.AppendLine("Введите цену");
            if (AgeCategory.Text.Length == 0 || Int32.TryParse(AgeCategory.Text, out int agecategory) == false) errors.AppendLine("Введите возрастной рейтинг");
            if (FactoryName.Text.Length == 0) errors.AppendLine("Введите название предприятия");
            if (CityFactory.Text.Length == 0) errors.AppendLine("Введите город производитель");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            toy.Name = NameToy.Text;
            toy.Price = Convert.ToInt32(Price.Text);
            toy.Kol = Convert.ToInt32(Kol.Text);
            toy.AgeCategory = Convert.ToInt32(AgeCategory.Text);
            toy.FactoryName = FactoryName.Text;
            toy.CityFactory = CityFactory.Text;

            try
            {
                db.SaveChanges();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Qiut(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

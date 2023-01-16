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

namespace Prakt18_praktika_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DetdomEntities db = DetdomEntities.GetContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db.Toys.Load();
            ToyCollection.ItemsSource = db.Toys.Local.ToBindingList();
        }

        private void AddToy_Button(object sender, RoutedEventArgs e)
        {
            AddToy_Button add = new AddToy_Button();
            add.ShowDialog();
        }

        private void EditToy_Button(object sender, RoutedEventArgs e)
        {
            int indexRow = ToyCollection.SelectedIndex;
            if (indexRow != -1)
            {
                Toy row = (Toy)ToyCollection.Items[indexRow];
                Data.Id = row.Id;
                EditToy edit = new EditToy();
                edit.ShowDialog();
                db.SaveChanges();
                ToyCollection.Items.Refresh();
                ToyCollection.Focus();
            }
            else MessageBox.Show("Не выбрано");
        }

        private void SeeToy_Button(object sender, RoutedEventArgs e)
        {
            int indexRow = ToyCollection.SelectedIndex;
            if (indexRow != -1)
            {
                Toy row = (Toy)ToyCollection.Items[indexRow];
                Data.Id = row.Id;
                SeeToy see = new SeeToy();
                see.ShowDialog();
                ToyCollection.Items.Refresh();
            }
            else MessageBox.Show("Не выбрано");
        }

        private void DeleteToy_Button(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Удалить запись???", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (res == MessageBoxResult.Yes)
            {
                try
                {
                    Toy row = (Toy)ToyCollection.SelectedItems[0];
                    db.Toys.Remove(row);
                    db.SaveChanges();
                    ToyCollection.ItemsSource = db.Toys.Local.ToBindingList();
                    ToyCollection.Items.Refresh();
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Выберите запись");
                }
            }
        }

        private void Quit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Spravka(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Сведения об ассортименте игрушек в магазине. База данных должна содержать следующую информацию:\n" +
                "название игрушки, ее цену, количество, возрастную категорию детей, для которых она предназначена, а также название фабрики и города, где изготовлена игрушка.");
        }

        private void DeleteFilter_Button(object sender, RoutedEventArgs e)
        {
            ToyCollection.ItemsSource = db.Toys.Local.ToBindingList();
        }

        private void SortPrice_Button(object sender, RoutedEventArgs e)
        {
            var priceA1 = from p in db.Toys
                          where p.Price > 500
                          select p;
            ToyCollection.ItemsSource = priceA1.ToList();
        }

        private void ProizvodFilter_Button(object sender, RoutedEventArgs e)
        {
            var proizvA1 = from p in db.Toys
                           where p.FactoryName.StartsWith("ООО")
                           select p;
            ToyCollection.ItemsSource = proizvA1.ToList();
        }

        private void UpdateKolToy_Button(object sender, RoutedEventArgs e)
        {
            int numberIns = db.Database.ExecuteSqlCommand("UPDATE Toy SET Kol='10' WHERE Kol<10");
            db.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            ToyCollection.Items.Refresh();
        }

        private void DeleteNull_Button(object sender, RoutedEventArgs e)
        {
            int numberDel = db.Database.ExecuteSqlCommand("DELETE FROM Toy Where Kol=0");
            db.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            ToyCollection.Items.Refresh();
        }

        private void Price500Menee_Button(object sender, RoutedEventArgs e)
        {
            var priceA1 = from p in db.Toys
                          where p.Price < 500
                          select p;
            ToyCollection.ItemsSource = priceA1.ToList();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            PasswordWindow passwordWindow = new PasswordWindow();
            passwordWindow.ShowDialog();
            if (DataBtn.Login == false) Close();
            if (DataBtn.Right == "Администратор") ;
            if (DataBtn.Right == "Модератор")
            {
                tab1.IsEnabled = false;
            }
            if (DataBtn.Right == "Пользователь")
            {
                tab1.IsEnabled = false;
                DeleteTovar.IsEnabled = false;
                UpdateTovar.IsEnabled = false;
            }
            if (DataBtn.Right == "Клиент" )
            {
                tab1.IsEnabled = false;
                DeleteTovar.IsEnabled = false;
                UpdateTovar.IsEnabled = false;
            }
            mainwindow.Title = DataBtn.Familia + " " + DataBtn.Name + " " + DataBtn.Otchestvo + " - " + DataBtn.Right;
        }
    }
}


//private DetdomEntities context;
//public DetdomEntities GetContext()
//{
//    if (context == null)
//        null = new DetdomEntities();
//    return context;
//}

namespace PrimerBD
{
    public static class Data
    {
        public static int Id;
    }
}
namespace PrimerBTN
{
    public static class DataBtn
    {
        public static bool Login = false;
        public static string Familia;
        public static string Name;
        public static string Otchestvo;
        public static string Right;
    }
}

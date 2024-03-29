﻿using Prakt18_praktika_;
using PrimerBD;
using PrimerBTN;
using PrimerBTS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        DetDomContext db = DetDomContext.GetContext();
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


        private void Window_Initialized(object sender, EventArgs e)
        {
            PasswordWindow passwordWindow = new PasswordWindow();
            passwordWindow.ShowDialog();
            label.Content += $" {DataBtn.Familia} {DataBtn.Name} {DataBtn.Otchestvo}!";
            if (DataBtn.Login == false) Close();
            if (DataBtn.Right == "Администратор");
            if (DataBtn.Right == "Модератор")
            {
                tab1.IsEnabled = false;
            }
            if (DataBtn.Right == "Пользователь")
            {
                tab1.IsEnabled = false;
                tabtab1.IsEnabled = false;
                tabtab2.IsEnabled = false;
            }
            if (DataBtn.Right == "Клиент" )
            {
                tab1.IsEnabled = false;
                tabtab1.IsEnabled = false;
                tabtab2.IsEnabled = false;
            }
        }

        private void Relogin_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            Poisk poisk = new Poisk();
            poisk.ShowDialog();
            if (DataBasic.bs != null)
            {
                ToyCollection.ItemsSource = DataBasic.bs.ToList();
            }
        }

        private void FiltAd_Click(object sender, RoutedEventArgs e)
        {
            UpdateFilter udp = new UpdateFilter();
            udp.ShowDialog();
            db.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            ToyCollection.Items.Refresh();
        }

        private void FiltDel_Click(object sender, RoutedEventArgs e)
        {
            DeleteFilter dl = new DeleteFilter();
            dl.ShowDialog();
            db.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            ToyCollection.Items.Refresh();
        }
    }
}

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

namespace PrimerBTS
{
    public static class DataBasic
    {
        public static System.Linq.IQueryable<Toy> bs;
    }
}
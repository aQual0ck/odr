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
using odr.Classes;

namespace odr.Pages
{
    /// <summary>
    /// Interaction logic for PageUserSupplier.xaml
    /// </summary>
    public partial class PageUserSupplier : Page
    {
        public PageUserSupplier()
        {
            InitializeComponent();
            ListViewSuppliers.ItemsSource = DBModel.entObj.Supplier.ToList();

            if (string.IsNullOrEmpty(txbSearch.Text))
            {
                txbSearch.Text = "Введите для поиска";
                txbSearch.Foreground = Brushes.Gray;
                txbSearch.GotFocus += RemoveTextSearch;
                txbSearch.LostFocus += AddTextSearch;
            }

            cmbSort.SelectedIndex = 0;
            cmbFilter.SelectedIndex = 0;
        }

        private void menuMaterials_Click(object sender, RoutedEventArgs e)
        {
            Classes.FrameClass.frmObj.Navigate(new PageAdmin());
        }

        private void menuSuppliers_Click(object sender, RoutedEventArgs e)
        {
            Classes.FrameClass.frmObj.Navigate(new PageAdminSuppliers());
        }

        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            Classes.FrameClass.frmObj.Navigate(new PageLogin());
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbSort.SelectedIndex != 0)
            {
                cmbStandard.Content = "Без сортировки";
                cmbSort.Items.Refresh();
            }
            else
            {
                cmbStandard.Content = "Сортировка";
                cmbSort.Items.Refresh();
            }

            ApplyFilters();
        }

        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void cmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFilter.SelectedIndex != 0)
            {
                cmbFilterStandard.Content = "Все типы";
                cmbFilter.Items.Refresh();
            }
            else
            {
                cmbFilterStandard.Content = "Фильтрация";
                cmbFilter.Items.Refresh();
            }

            ApplyFilters();
        }

        private void ApplyFilters()
        {
            string searchText = txbSearch.Text.ToLower();

            var query = DBModel.entObj.Supplier.AsQueryable();

            //По убыванию (рейтинг)
            if (cmbSort.SelectedIndex == 1)
                query = query.OrderByDescending(s => s.QualityRating);

            //По возрастанию (рейтинг)
            if (cmbSort.SelectedIndex == 2)
                query = query.OrderBy(s => s.QualityRating);

            //По дате начала (старее)
            if (cmbSort.SelectedIndex == 3)
                query = query.OrderByDescending(s => s.StartDate);

            //По дате начала (новее)
            if (cmbSort.SelectedIndex == 4)
                query = query.OrderBy(s => s.StartDate);

            //ЗАО
            if (cmbFilter.SelectedIndex == 1)
                query = query.Where(s => s.SupplierType == " ЗАО");

            //МКК
            if (cmbFilter.SelectedIndex == 2)
                query = query.Where(s => s.SupplierType == " МКК");

            //МФО
            if (cmbFilter.SelectedIndex == 3)
                query = query.Where(s => s.SupplierType == " МФО");

            //ОАО
            if (cmbFilter.SelectedIndex == 4)
                query = query.Where(s => s.SupplierType == " ОАО");

            //ООО
            if (cmbFilter.SelectedIndex == 5)
                query = query.Where(s => s.SupplierType == " ООО");

            //ПАО
            if (cmbFilter.SelectedIndex == 6)
                query = query.Where(s => s.SupplierType == " ПАО");

            if (txbSearch.Text != "Введите для поиска" && !string.IsNullOrEmpty(txbSearch.Text))
                query = query.Where(s => s.Title.ToLower().Contains(searchText));

            ListViewSuppliers.ItemsSource = query.ToList();
        }

        private void RemoveTextSearch(object sender, EventArgs e)
        {
            if (txbSearch.Text == "Введите для поиска")
            {
                txbSearch.Text = "";
                txbSearch.Foreground = Brushes.Black;
            }
        }

        private void AddTextSearch(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbSearch.Text))
            {
                txbSearch.Text = "Введите для поиска";
                txbSearch.Foreground = Brushes.Gray;
            }
        }

        private void ListViewSuppliers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListViewSuppliers.SelectedItem != null)
            {
                var supplier = ListViewSuppliers.SelectedItem;
                Classes.FrameClass.frmObj.Navigate(new PageEditSupplier(supplier));
            }
        }
    }
}

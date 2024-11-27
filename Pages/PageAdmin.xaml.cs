using odr.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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

namespace odr.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAdmin.xaml
    /// </summary>
    public partial class PageAdmin : Page
    {
        private List<MaterialType> _type;
        public PageAdmin()
        {
            InitializeComponent();

            cmbFilter.SelectedValuePath = "Title";
            cmbFilter.DisplayMemberPath = "Title";
            _type = Classes.DBModel.entObj.MaterialType.ToList();
            MaterialType def = new MaterialType 
            { 
                ID = 0, 
                Title = "Фильтрация", 
                DefectedPercent = 0 
            };
            _type.Insert(0, def);
            cmbFilter.ItemsSource = _type;
            cmbFilter.SelectedIndex = 0;

            cmbSort.SelectedIndex = 0;

            ListViewMaterials.ItemsSource = DBModel.entObj.Material.ToList();
            if (string.IsNullOrEmpty(txbSearch.Text))
            {
                txbSearch.Text = "Введите для поиска";
                txbSearch.Foreground = Brushes.Gray;
                txbSearch.GotFocus += RemoveTextSearch;
                txbSearch.LostFocus += AddTextSearch;
            }
            //DGMaterials.Items.Clear();
            //DGMaterials.ItemsSource = Classes.DBModel.entObj.Material.ToList();
        }

        private void menuMaterials_Click(object sender, RoutedEventArgs e)
        {
            Classes.FrameClass.frmObj.Navigate(new PageAdmin());
        }

        private void menuSuppliers_Click(object sender, RoutedEventArgs e)
        {
            Classes.FrameClass.frmObj.Navigate(new PageAdminSuppliers());
        }

        private void menuAdd_Click(object sender, RoutedEventArgs e)
        {
            Classes.FrameClass.frmObj.Navigate(new PageAddMaterial());
        }

        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            Classes.FrameClass.frmObj.Navigate(new PageLogin());
        }

        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilters();
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

        private void cmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFilter.SelectedIndex != 0)
            {
                _type.ElementAt(0).Title = "Все типы";
                cmbFilter.Items.Refresh();
            }
            else
            {
                _type.ElementAt(0).Title = "Фильтрация";
                cmbFilter.Items.Refresh();
            }

            ApplyFilters();
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

        private void ListViewMaterials_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListViewMaterials.SelectedItem != null)
            {
                var material = ListViewMaterials.SelectedItem;
                Classes.FrameClass.frmObj.Navigate(new PageEditMaterial(material));
            }
        }

        private void ApplyFilters()
        {
            int typeId = Convert.ToInt32(TypeDescriptor.GetProperties(cmbFilter.SelectedItem)["ID"].GetValue(cmbFilter.SelectedItem));
            string searchText = txbSearch.Text.ToLower();

            var query = DBModel.entObj.Material.AsQueryable();

            //if (cmbSort.SelectedIndex == 0)
            //    query = query;

            //По убыванию (цена)
            if (cmbSort.SelectedIndex == 1)
                query = query.OrderByDescending(m => m.Cost);

            //По возрастанию (цена)
            if (cmbSort.SelectedIndex == 2)
                query = query.OrderBy(m => m.Cost);

            //По убыванию (остаток)
            if (cmbSort.SelectedIndex == 3)
                query = query.OrderByDescending(m => m.CountInStock);

            //По возрастанию (остаток)
            if (cmbSort.SelectedIndex == 4)
                query = query.OrderBy(m => m.CountInStock);

            //По убыванию (минимальное кол-во)
            if (cmbSort.SelectedIndex == 5)
                query = query.OrderByDescending(m => m.MinCount);

            //По возрастанию (минимальное кол-во)
            if (cmbSort.SelectedIndex == 6)
                query = query.OrderBy(m => m.MinCount);

            if (typeId != 0)
                query = query.Where(m => m.MaterialTypeID == typeId);

            if (txbSearch.Text != "Введите для поиска" && !string.IsNullOrEmpty(txbSearch.Text))
                query = query.Where(m => m.Title.ToLower().Contains(searchText));

            ListViewMaterials.ItemsSource = query.ToList();
        }
    }
}

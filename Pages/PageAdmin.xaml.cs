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

        }
        public static Supplier S;
        private void CreateStackPanel(int id)
        {
            var source = DBModel.entObj.Material.AsQueryable();
            var item = source.FirstOrDefault(x => x.ID == id);
            StackPanel sp = new StackPanel
            {
                Height = 100,
                Width = 510,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Orientation = Orientation.Horizontal,
            };
            StackPanel sub_sp = new StackPanel
            {
                Height = 75,
                Width = 355,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Orientation = Orientation.Vertical,
                Margin = new Thickness(25, 0, 0, 0)
            };
            StackPanel sub_sub_sp = new StackPanel
            {
                Height = 75,
                Width = 100,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left,
            };
            Image image = new Image
            {
                Source = (ImageSource)new ImageSourceConverter().ConvertFromString($"{Directory.GetParent(Environment.CurrentDirectory).Parent.FullName}\\{TypeDescriptor.GetProperties(item)["Image"].GetValue(item)}"),
                Width = 60,
                Height = 45, 
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
            };
            TextBlock tb_title = new TextBlock
            {
                Text = $"{TypeDescriptor.GetProperties(item.MaterialType)["Title"].GetValue(item.MaterialType)} | {TypeDescriptor.GetProperties(item)["Title"].GetValue(item)}"
            };
            TextBlock tb_min = new TextBlock
            {
                Text = $"Минимальное количество: {TypeDescriptor.GetProperties(item)["MinCount"].GetValue(item)} {TypeDescriptor.GetProperties(item)["Unit"].GetValue(item)}"
            };

            TextBlock tb_Suppliers = new TextBlock
            {
                Text = $"Поставщики: ",
            };

            for (int i = 1; i <= item.Supplier.Count(); i++)
            {
                if (i == item.Supplier.Count())
                {
                    tb_Suppliers.Text += $" {DBModel.entObj.Supplier.FirstOrDefault(x => x.ID == i).Title}";
                }
                else if (i % 3 == 0)
                {
                    tb_Suppliers.Text += $" {DBModel.entObj.Supplier.FirstOrDefault(x => x.ID == i).Title},\n";
                }
                else
                {
                    tb_Suppliers.Text += $" {DBModel.entObj.Supplier.FirstOrDefault(x => x.ID == i).Title},";
                }
            }

            TextBlock tb_Stock = new TextBlock
            {
                Text = $"Остаток: {TypeDescriptor.GetProperties(item)["CountInStock"].GetValue(item)}"
            };

            sub_sp.Children.Add(tb_title);
            sub_sp.Children.Add(tb_min);
            sub_sp.Children.Add(tb_Suppliers);
            sub_sub_sp.Children.Add(tb_Stock);
            sp.Children.Add(image);
            sp.Children.Add(sub_sp);
            sp.Children.Add(sub_sub_sp);
            ListViewMaterials.Items.Add(sp);
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
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbSort.SelectedIndex != 0)
            {
                cmbStandard.Content = "По алфавиту";
                cmbSort.Items.Refresh();
            }
            else
            {
                cmbStandard.Content = "Сортировка";
                cmbSort.Items.Refresh();
            }

            //string selected = cmbSort.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last();
            //switch (selected) 
            //{
            //    case "По алфавиту":
            //        CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListViewMaterials.ItemsSource);
            //        break;
            //}
        }
    }
}

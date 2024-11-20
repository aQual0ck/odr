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
        public PageAdmin()
        {
            InitializeComponent();
            DataContext = DBModel.entObj.Material.ToList();
            for (int i = 1; i <= DBModel.entObj.Material.Count(); i++)
            {
                CreateStackPanel(i);
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
            var item = DBModel.entObj.Material.FirstOrDefault(x => x.ID == id);
            StackPanel sp = new StackPanel
            {
                Height = 100,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Orientation = Orientation.Horizontal,
            };
            StackPanel sub_sp = new StackPanel
            {
                Height = 75,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Orientation = Orientation.Vertical,
                Margin = new Thickness(25, 0, 0, 0)
            };
            Image image = new Image
            {
                Source = (ImageSource)new ImageSourceConverter().ConvertFromString($"{Directory.GetParent(Environment.CurrentDirectory).Parent.FullName}\\materials\\picture.png"),
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
                Text = $"Минимальное количество: {TypeDescriptor.GetProperties(item)["MinCount"].GetValue(item)} шт"
            };

            TextBlock tb_Suppliers = new TextBlock
            {
                Text = $"Поставщики: "
            };

            for (int i = 1; i <= item.Supplier.Count(); i++)
            {
                if (i == item.Supplier.Count())
                {
                    tb_Suppliers.Text += $" {DBModel.entObj.Supplier.FirstOrDefault(x => x.ID == i).Title}";
                }
                else
                {
                    tb_Suppliers.Text += $" {DBModel.entObj.Supplier.FirstOrDefault(x => x.ID == i).Title},";
                }
            }

            sub_sp.Children.Add(tb_title);
            sub_sp.Children.Add(tb_min);
            sub_sp.Children.Add(tb_Suppliers);
            sp.Children.Add(image);
            sp.Children.Add(sub_sp);
            ListViewMaterials.Items.Add(sp);
        }
    }
}

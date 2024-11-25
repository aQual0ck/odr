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
using System.IO;
using Microsoft.Win32;

namespace odr.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAddMaterial.xaml
    /// </summary>
    public partial class PageAddMaterial : Page
    {
        private string _filepath;
        private Classes.Material mat;
        private List<Classes.Supplier> _sup = new List<Classes.Supplier>();
        public PageAddMaterial()
        {
            InitializeComponent();
            cmbSupplier.SelectedValuePath = "Title";
            cmbSupplier.DisplayMemberPath = "Title";
            cmbSupplier.ItemsSource = Classes.DBModel.entObj.Supplier.ToList();
        }

        private void cmbSupplier_TextChanged(object sender, RoutedEventArgs e)
        {
            cmbSupplier.IsDropDownOpen = true;
            cmbSupplier.ItemsSource = Classes.DBModel.entObj.Supplier.Where(s => s.Title.ToLower().Contains(cmbSupplier.Text.ToLower())).ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            mat = new Classes.Material()
            {
                Title = txbTitle.Text,
                CountInPack = Convert.ToInt32(txbCountInPack.Text),
                Unit = txbUnit.Text,
                CountInStock = Convert.ToInt32(txbCountInStock.Text),
                MinCount = Convert.ToInt32(txbMinCount.Text),
                Cost = Convert.ToInt32(txbCost.Text),

                Supplier = _sup
            };
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            _sup.Add(cmbSupplier.SelectedItem as Classes.Supplier);
            if (_sup.Count == 1)
                tbSupplier.Text += $"{cmbSupplier.SelectedValue}";
            else
                tbSupplier.Text += $", {cmbSupplier.SelectedValue}";
            cmbSupplier.ItemsSource = Classes.DBModel.entObj.Supplier.ToList();
        }

        private void btnPick_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "D:\\Projects\\Csharp\\odr\\materials";

            bool? result = ofd.ShowDialog();

            if (result == true)
            {
                _filepath = ofd.FileName.Replace(ofd.FileName.Substring(0, ofd.FileName.IndexOf("\\materials")), "");
                txbImage.Text = _filepath;
            }
        }
    }
}

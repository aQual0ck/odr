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
using System.ComponentModel;
using odr.Classes;

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
            int mtid = Convert.ToInt32(TypeDescriptor.GetProperties(cmbMaterialType.SelectedItem)["ID"].GetValue(cmbMaterialType.SelectedItem));
            mat = new Classes.Material()
            {
                Title = txbTitle.Text,
                CountInPack = Convert.ToInt32(txbCountInPack.Text),
                Unit = txbUnit.Text,
                CountInStock = Convert.ToInt32(txbCountInStock.Text),
                MinCount = Convert.ToInt32(txbMinCount.Text),
                Cost = Convert.ToInt32(txbCost.Text),
                MaterialTypeID = mtid,
                Supplier = _sup
            };
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            _sup.Add(cmbSupplier.SelectedItem as Classes.Supplier);

            Run run = new Run($"\n{cmbSupplier.SelectedValue}");
            Run run1 = new Run(" (");
            Run runDel = new Run("Удалить");
            Hyperlink btnDel = new Hyperlink(runDel);
            btnDel.Click += btnDel_Click;
            Run run2 = new Run(")");
            tbSupplier.Inlines.Add(run);
            tbSupplier.Inlines.Add(run1);
            tbSupplier.Inlines.Add(btnDel);
            tbSupplier.Inlines.Add(run2);
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

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            Hyperlink hp = e.Source as Hyperlink;
            var run = tbSupplier.Inlines.FirstOrDefault() as Run;
            string supplier = run.Text.Substring(1, run.Text.Length - 1);
            Supplier sup = DBModel.entObj.Supplier.FirstOrDefault(s => s.Title == supplier);
            _sup.Remove(sup);
        }
    }
}

using Microsoft.Win32;
using odr.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for PageEditMaterial.xaml
    /// </summary>
    public partial class PageEditMaterial : Page
    {
        private string _filepath;
        private MaterialType mt;
        private Material _mat;
        private List<Supplier> _sup = new List<Supplier>();
        public PageEditMaterial(object selected_mat)
        {
            InitializeComponent();
            DataContext = selected_mat;
            var mid = TypeDescriptor.GetProperties(DataContext)["ID"].GetValue(DataContext);
            _mat = DBModel.entObj.Material.FirstOrDefault(m => m.ID == (int)mid);

            ICollection<Supplier> suppliers = (ICollection<Supplier>)TypeDescriptor.GetProperties(DataContext)["Supplier"].GetValue(DataContext);
            _sup = suppliers.ToList();
            var mtid = TypeDescriptor.GetProperties(DataContext)["MaterialTypeID"].GetValue(DataContext);
            mt = Classes.DBModel.entObj.MaterialType.FirstOrDefault(m => m.ID == (int)mtid);

            cmbMaterialType.SelectedValuePath = "Title";
            cmbMaterialType.DisplayMemberPath = "Title";
            cmbMaterialType.ItemsSource = Classes.DBModel.entObj.MaterialType.ToList();
            cmbMaterialType.SelectedValue = mt.Title;

            foreach (Classes.Supplier s in _sup)
            {
                Run run = new Run($"\n{s.Title}");
                Hyperlink btnDel = new Hyperlink(run);
                btnDel.Click += btnDel_Click;
                tbSupplier.Inlines.Add(btnDel);
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            Hyperlink hp = e.Source as Hyperlink;
            var run = hp.Inlines.FirstOrDefault() as Run;
            string supplier = run.Text.Substring(1, run.Text.Length - 1);
            Supplier sup = DBModel.entObj.Supplier.FirstOrDefault(s => s.Title == supplier);
            if (MessageBox.Show("Удалить поставщика?", "Удаление поставщика", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _sup.Remove(sup);
                tbSupplier.Inlines.Remove(tbSupplier.Inlines.FirstOrDefault(s => s == hp));
            }
        }

        private void menuBack_Click(object sender, RoutedEventArgs e)
        {
            Classes.FrameClass.frmObj.Navigate(new PageAdmin());
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

        private void cmbSupplier_TextChanged(object sender, TextChangedEventArgs e)
        {
            cmbSupplier.IsDropDownOpen = true;
            cmbSupplier.ItemsSource = Classes.DBModel.entObj.Supplier.Where(s => s.Title.ToLower().Contains(cmbSupplier.Text.ToLower())).ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            _sup.Add(cmbSupplier.SelectedItem as Classes.Supplier);

            Run run = new Run($"\n{cmbSupplier.SelectedValue}");
            Hyperlink btnDel = new Hyperlink(run);
            btnDel.Click += btnDel_Click;
            tbSupplier.Inlines.Add(btnDel);
            cmbSupplier.ItemsSource = Classes.DBModel.entObj.Supplier.ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            int mtid = Convert.ToInt32(TypeDescriptor.GetProperties(cmbMaterialType.SelectedItem)["ID"].GetValue(cmbMaterialType.SelectedItem));
            string txb = txbCost.Text.Replace('.', ',');
            decimal cost = Convert.ToDecimal(txb);

            _mat.Title = txbTitle.Text;
            _mat.CountInPack = Convert.ToInt32(txbCountInPack.Text);
            _mat.Unit = txbUnit.Text;
            _mat.CountInStock = Convert.ToInt32(txbCountInStock.Text);
            _mat.MinCount = Convert.ToInt32(txbMinCount.Text);
            _mat.Cost = cost;
            _mat.Image = txbImage.Text;
            _mat.MaterialTypeID = mtid;
            _mat.Supplier = _sup;

            Classes.DBModel.entObj.SaveChanges();

            MessageBox.Show("Сохранено");
        }

        private void menuDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены?", "Удаление материала", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                DBModel.entObj.Material.Remove(_mat);
                DBModel.entObj.SaveChanges();
                FrameClass.frmObj.Navigate(new PageAdmin());
            }
        }
    }
}

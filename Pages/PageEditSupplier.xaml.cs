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
    /// Interaction logic for PageEditSupplier.xaml
    /// </summary>
    public partial class PageEditSupplier : Page
    {
        private Supplier _sup;
        private List<Material> _mat = new List<Material>();
        public PageEditSupplier(object selected_sup)
        {
            InitializeComponent();
            DataContext = selected_sup;
            var sid = TypeDescriptor.GetProperties(DataContext)["ID"].GetValue(DataContext);
            _sup = DBModel.entObj.Supplier.FirstOrDefault(m => m.ID == (int)sid);

            cmbMaterial.SelectedValuePath = "Title";
            cmbMaterial.DisplayMemberPath = "Title";
            cmbMaterial.ItemsSource = Classes.DBModel.entObj.Material.ToList();

            ICollection<Material> materials = (ICollection<Material>)TypeDescriptor.GetProperties(DataContext)["Material"].GetValue(DataContext);
            _mat = materials.ToList();

            foreach (Material m in _mat)
            {
                Run run = new Run($"\n{m.Title}");
                Hyperlink btnDel = new Hyperlink(run);
                btnDel.Click += btnDel_Click;
                tbMaterial.Inlines.Add(btnDel);
            }
        }

        private void menuDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены?", "Удаление материала", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                DBModel.entObj.Supplier.Remove(_sup);
                DBModel.entObj.SaveChanges();
                FrameClass.frmObj.Navigate(new PageAdmin());
            }
        }

        private void menuBack_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frmObj.Navigate(new PageAdminSuppliers());
        }

        private void cmbMaterial_TextChanged(object sender, TextChangedEventArgs e)
        {
            cmbMaterial.IsDropDownOpen = true;
            cmbMaterial.ItemsSource = Classes.DBModel.entObj.Material.Where(m => m.Title.ToLower().Contains(cmbMaterial.Text.ToLower())).ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            _mat.Add(cmbMaterial.SelectedItem as Classes.Material);

            Run run = new Run($"\n{cmbMaterial.SelectedValue}");
            Hyperlink btnDel = new Hyperlink(run);
            btnDel.Click += btnDel_Click;
            tbMaterial.Inlines.Add(btnDel);
            cmbMaterial.ItemsSource = Classes.DBModel.entObj.Material.ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string date = dpStartDate.SelectedDate?.ToString(App.DateFormat);
            DateTime dt = DateTime.Parse(date);

            _sup.Title = txbTitle.Text;
            _sup.INN = txbINN.Text;
            _sup.StartDate = dt;
            _sup.QualityRating = Convert.ToInt32(txbQualityRating.Text);
            _sup.SupplierType = txbSupplierType.Text;
            _sup.Material = _mat;

            Classes.DBModel.entObj.SaveChanges();

            MessageBox.Show("Сохранено");
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            Hyperlink hp = e.Source as Hyperlink;
            var run = hp.Inlines.FirstOrDefault() as Run;
            string material = run.Text.Substring(1, run.Text.Length - 1);
            Material mat = DBModel.entObj.Material.FirstOrDefault(s => s.Title == material);
            if (MessageBox.Show("Удалить поставщика?", "Удаление поставщика", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _mat.Remove(mat);
                tbMaterial.Inlines.Remove(tbMaterial.Inlines.FirstOrDefault(s => s == hp));
            }
        }
    }
}

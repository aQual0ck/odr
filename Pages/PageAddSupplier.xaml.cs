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

namespace odr.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAddSupplier.xaml
    /// </summary>
    public partial class PageAddSupplier : Page
    {
        private Classes.Supplier sup;
        private List<Classes.Material> _mat = new List<Classes.Material>();
        public PageAddSupplier()
        {
            InitializeComponent();
            cmbMaterial.SelectedValuePath = "Title";
            cmbMaterial.DisplayMemberPath = "Title";
            cmbMaterial.ItemsSource = Classes.DBModel.entObj.Material.ToList();
        }

        private void menuBack_Click(object sender, RoutedEventArgs e)
        {
            Classes.FrameClass.frmObj.Navigate(new PageAdminSuppliers());
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
            sup = new Classes.Supplier()
            {
                Title = txbTitle.Text,
                INN = txbINN.Text,
                StartDate = dt,
                QualityRating = Convert.ToInt32(txbQualityRating.Text),
                SupplierType = txbSupplierType.Text,
                Material = _mat
            };
            Classes.DBModel.entObj.Supplier.Add(sup);
            Classes.DBModel.entObj.SaveChanges();

            MessageBox.Show("Сохранено");
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            Hyperlink hp = e.Source as Hyperlink;
            var run = hp.Inlines.FirstOrDefault() as Run;
            string material = run.Text.Substring(1, run.Text.Length - 1);
            Classes.Material mat = Classes.DBModel.entObj.Material.FirstOrDefault(m => m.Title == material);
            if (MessageBox.Show("Удалить материал?", "Удаление материала", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _mat.Remove(mat);
                tbMaterial.Inlines.Remove(tbMaterial.Inlines.FirstOrDefault(m => m == hp));
            }
        }
    }
}

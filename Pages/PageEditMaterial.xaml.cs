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
        private ICollection<Supplier> _sup;
        public PageEditMaterial(object selected_mat)
        {
            InitializeComponent();
            DataContext = selected_mat;

            _sup = (ICollection<Supplier>)TypeDescriptor.GetProperties(DataContext)["Supplier"].GetValue(DataContext);

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

        }

        private void cmbSupplier_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

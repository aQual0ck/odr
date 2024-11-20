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
    /// Логика взаимодействия для PageAdminSuppliers.xaml
    /// </summary>
    public partial class PageAdminSuppliers : Page
    {
        public PageAdminSuppliers()
        {
            InitializeComponent();
            DGSuppliers.ItemsSource = Classes.DBModel.entObj.Supplier.ToList();
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
            Classes.FrameClass.frmObj.Navigate(new PageAddSupplier());
        }

        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            Classes.FrameClass.frmObj.Navigate(new PageLogin());
        }
    }
}

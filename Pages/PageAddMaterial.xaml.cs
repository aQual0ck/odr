﻿using System;
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

            cmbMaterialType.SelectedValuePath = "Title";
            cmbMaterialType.DisplayMemberPath = "Title";
            cmbMaterialType.ItemsSource = Classes.DBModel.entObj.MaterialType.ToList();
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
                Image = txbImage.Text,
                MaterialTypeID = mtid,
                Supplier = _sup
            };
            Classes.DBModel.entObj.Material.Add(mat);
            Classes.DBModel.entObj.SaveChanges();

            MessageBox.Show("Сохранено");
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
            FrameClass.frmObj.Navigate(new PageAdmin());
        }
    }
}

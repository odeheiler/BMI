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

namespace BMI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Person per;
        public MainWindow()
        {

            InitializeComponent();
            per = new Person()
            {
                Height = 0,
                Weight = 0
            };
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                per.Height = Convert.ToDouble(heightBox.Text);
                per.Weight = Convert.ToDouble(weightBox.Text);
                per.IsMale = Male.IsChecked;

            }

            catch (Exception)
            {

                MessageBox.Show("Please Valid Values");
            }
        }

        private void BmiButton_OnClick(object sender, RoutedEventArgs e)
        {
            per.Neck = Convert.ToDouble(neckBox.Text);
            per.Waist = Convert.ToDouble(waistBox.Text);
            per.Hip = Convert.ToDouble(HipBox.Text);
            bmiBox.Text = per.CalculateBMI();

        }
    }
}
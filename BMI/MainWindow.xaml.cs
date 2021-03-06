﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
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

        

        private void BmiButton_OnClick(object sender , RoutedEventArgs e)
        {
            try
            {
                per.Height = Convert.ToDouble(heightBox.Text);
                per.Weight = Convert.ToDouble(weightBox.Text);
                bmiBox.Text = per.CalculateBMI();
            }
            catch (Exception)
            {

                MessageBox.Show("Unable to peform calculation.");
            }
        }
        private void FatButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                per.Height = Convert.ToDouble(heightBox.Text);
                per.Weight = Convert.ToDouble(weightBox.Text);
                per.IsMale = Male.IsChecked;
                per.Neck = Convert.ToDouble(neckBox.Text);
                per.Waist = Convert.ToDouble(waistBox.Text);
                if (per.IsMale==false)
                {
                    per.Hip = Convert.ToDouble(HipBox.Text);
                    fatBox.Text=per.CalculateBodyFat();
                }
                else
                {
                    fatBox.Text = per.CalculateBodyFat();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please Enter Valid Values.");
            }

        }

        private void HipBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            
            if (HipBox.Focus()==true&&HipBox.Text.Equals("(If Female)"))
            {
                HipBox.Text = "";
            }
        }

        private void CalorieButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                per.Height = Convert.ToDouble(heightBox.Text);
                per.Weight = Convert.ToDouble(weightBox.Text);
                per.IsMale = Male.IsChecked;
                    
                MaintenenceBox.Text = per.CalculateMaintenenceCalories(ActivityComboBox.Text, Convert.ToDouble(bfCalBox.Text));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

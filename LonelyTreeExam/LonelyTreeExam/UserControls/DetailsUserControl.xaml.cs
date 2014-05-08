﻿using Domain.Controller;
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

namespace LonelyTreeExam.UserControls
{
    /// <summary>
    /// Interaction logic for DetailsUserControl.xaml
    /// </summary>
    public partial class DetailsUserControl : UserControl
    {
        public DetailsUserControl(PaymentController controller)
        {
            paymentController = controller;
            InitializeComponent();
            attachmentsUserControl.Content = new AttachmentsUserControl();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private PaymentController paymentController;

    }
}

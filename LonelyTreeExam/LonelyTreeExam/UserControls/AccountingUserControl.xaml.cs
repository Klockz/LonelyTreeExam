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

namespace LonelyTreeExam.UserControls
{
    /// <summary>
    /// Interaction logic for AccountingUserControl.xaml
    /// </summary>
    public partial class AccountingUserControl : UserControl
    {
        public AccountingUserControl()
        {
            InitializeComponent();
            initializeDataGrids();
            detailedView = new DetailsUserControl();        
            collapsePlusImage = new BitmapImage(new Uri("/Images/collapse-plus.png", UriKind.Relative));
            collapseMinImage = new BitmapImage(new Uri("/Images/collapse-min.png", UriKind.Relative));
            collapseDetailedView();
        }

        private DetailsUserControl detailedView;
        private BitmapImage collapsePlusImage;
        private BitmapImage collapseMinImage;

        private void initializeDataGrids()
        {
            DataGridUserControl currentPayments = new DataGridUserControl("Archive",
                new BitmapImage(new Uri("/Images/book_add2.png", UriKind.Relative)),
                "Move selected payment to archive");
            DataGridUserControl archivedPayments = new DataGridUserControl("Restore", 
                new BitmapImage(new Uri("/Images/book_next2.png", UriKind.Relative)),
                "Move selected payment to current payments");

            currentPaymentsUserControl.Content = currentPayments;
            archiveUserControl.Content = archivedPayments;
        }

        private void collapseDetailedView()
        {
            if (detailsUserControl.Content != null)
            {
                detailsUserControl.Content = null;
                collapseImage.Source = collapsePlusImage;
                collapseButton.ToolTip = "Show details";
            }
            else
            {
                detailsUserControl.Content = detailedView;
                collapseImage.Source = collapseMinImage;
                collapseButton.ToolTip = "Hide details";
            }
        }

        private void collapseButton_Click(object sender, RoutedEventArgs e)
        {
            collapseDetailedView();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel.Channels;
using System.Windows;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using BoringGame;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BoringGame
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>

    public sealed partial class MainPage : Page
    {

        private double balance = 0.0;
        private LinkedList<Transaction> transactions = new LinkedList<Transaction>();
        private bool isIncome = false;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Income_Click(object sender, RoutedEventArgs e) {
            /* TODO: Add functionality for handling income */

        }

        private void Expense_Click(object sender, RoutedEventArgs e) {
            /* TODO: Add functionality for handling expense */
        }

        private void ActivityHistory_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            /* TODO: Implement this function (nothing should really change 
             * It justs lists the previous transactions made in this account
             */
        }

        /* This handles the transaction once the user has hit done */
        private void DoneClicked(object sender, RoutedEventArgs e) {
            /* We are earning money */
            if (isIncome)
            {
                try
                {
                    double value = Double.Parse(AmountTextBox.Text);
                    value = Math.Round(value, 2);

                    Transaction trans = new Transaction(value, DescripTextBox.Text, Type.Deposit);
                    transactions.AddLast(trans);
                    balance += value;
                    BalanceLabel.Text = "$" + Math.Round(balance, 2).ToString();
                }
                catch (Exception)
                {
                    MessageDialog dialogBox = new MessageDialog("Wrong format for amount, try again");
                    // Set the command that will be invoked by default
                    dialogBox.DefaultCommandIndex = 0;

                    // Set the command to be invoked when escape is pressed
                    dialogBox.CancelCommandIndex = 1;

                    // Show the message dialog
                    dialogBox.ShowAsync();
                }
                
            }
            /* We are spending money */
            else
            {
                try {
                    double value = Double.Parse(AmountTextBox.Text);
                    value = Math.Round(value, 2);

                    Transaction trans = new Transaction(value, DescripTextBox.Text, Type.Deposit);
                    transactions.AddLast(trans);
                    balance -= value;
                    BalanceLabel.Text = "$" + Math.Round(balance, 2).ToString();
                }
                catch (Exception) {
                    MessageDialog dialogBox = new MessageDialog("Wrong format for amount, try again");
                    // Set the command that will be invoked by default
                    dialogBox.DefaultCommandIndex = 0;

                    // Set the command to be invoked when escape is pressed
                    dialogBox.CancelCommandIndex = 1;

                    // Show the message dialog
                    dialogBox.ShowAsync();
                }
            }
        }
    }
}

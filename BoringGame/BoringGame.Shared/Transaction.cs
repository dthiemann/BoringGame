using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace BoringGame
{
    /* 
     * Enum for determining the type of transaction
     */
    public enum Type {
        Deposit,
        Withdraw
    }

    /*
     * Class that makes up a transaction, whether it is a deposit or a withdraw
     */ 
    class Transaction
    {
        public string amount { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public string imagePath { get; set; }

        public Transaction(double amount, string description, Type type)
        {
            this.amount = Math.Round(amount,2).ToString();

            if (description != null)
                this.description = description;
            else
                this.description = "No description";

            if (type == Type.Withdraw) {
                this.type = "Withdraw";
                this.imagePath = "ms-appx:///Assets/money_icons/withdraw_icon.png";
            }
            else {
                this.type = "Deposit";
                this.imagePath = "ms-appx:///Assets/money_icons/deposit_icon.png";
            }
        }

        public override string ToString()
        {
            string val = "$" + amount + ": " + description;
            return val;
        }


        /*
         * Determines if we have a valid transaction (i.e. no negative or 0 values)
         */
        public bool CheckIfValid()
        {
            if (double.Parse(amount) <= 0)
                return false;
            return true;
        }
    }
}

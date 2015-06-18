using System;
using System.Collections.Generic;
using System.Text;

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
        private float amount;
        private string description;
        private Type type; 

        public Transaction(float amount, string description, Type type)
        {
            this.amount = amount;
            if (description != null)
                this.description = description;
            else
                this.description = "No description";
            this.type = type;
        }

        /*
         * Determines if we have a valid transaction (i.e. no negative or 0 values)
         */
        public bool CheckIfValid()
        {
            if (amount <= 0)
                return false;
            return true;
        }
    }
}

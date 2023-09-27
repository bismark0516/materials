﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    public class CreditCardAccount : IAccountable
    {
        public decimal Balance
        {
            get
            {
                return Debt * -1;
            }

        }

        public string AccountHolderName { get; private set; }
        public string CardNumber { get; }

        public decimal Debt { get; private set; }


    public CreditCardAccount (string accountHolderName, string cardNumber)
        {
            AccountHolderName = accountHolderName;
            CardNumber = cardNumber;
        }


        public decimal Pay(decimal amountToPay)
        {
            if( amountToPay > 0.00M)
            {
                Debt= Debt -amountToPay ;
            }
            return Debt ;
        }
        
        public decimal Charge(decimal amountToCharge)
        {
            if(amountToCharge > 0.00M)
            {
                Debt = Debt + amountToCharge;
            }
            return Debt;
        }
    }


}



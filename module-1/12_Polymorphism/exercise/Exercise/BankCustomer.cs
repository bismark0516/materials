using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    public class BankCustomer
    {
        private IList<IAccountable> accounts = new List<IAccountable>();
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public decimal VipAmount { get; set; } = 25000;

        //public BankCustomer(decimal vipAmount)
        //{
        //    VipAmount = vipAmount;
        //}




        public IAccountable[] GetAccounts()
        {
            return accounts.ToArray();

        }

        public void AddAccount(IAccountable newAccount)
        {
            accounts.Add(newAccount);
        }
        public bool IsVip()
        {
            decimal totalBalance = 0;

            foreach (IAccountable account in accounts)
            {
                totalBalance += account.Balance;

            }
           
            if (totalBalance >= 25000M)
            {
                return true;
            }

            else
            {
                return false;
            }
            
        }


    }
}


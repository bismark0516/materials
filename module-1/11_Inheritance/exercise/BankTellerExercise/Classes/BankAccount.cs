namespace BankTellerExercise.Classes
{
    public class BankAccount
    {
        //constructors
        public BankAccount(string accountHolderName, string accountNumber)
        {
            AccountHolderName = accountHolderName;
            AccountNumber = accountNumber;
        }
       
        public BankAccount(string accountHolderName, string accountNumber, decimal balance)
        {
            AccountHolderName = accountHolderName;
            AccountNumber = accountNumber;
            Balance = balance;
        }

        //properties
        public string AccountHolderName { get; private set; }

        public string AccountNumber { get; }

        public decimal Balance { get; private set; }

        public decimal Deposit(decimal amountToDeposit)
        {
            if (amountToDeposit > 0)
            {
                Balance = Balance + amountToDeposit;
                return Balance;
            }
            else
            {
                return Balance;

            }
            
        }

        public virtual decimal Withdraw(decimal amountToWithdraw)
        {
            if(amountToWithdraw > 0.00M)
            {
                Balance = Balance - amountToWithdraw;
                return Balance;
            }
            else
            {
                return Balance;
            }
        }

    }
}

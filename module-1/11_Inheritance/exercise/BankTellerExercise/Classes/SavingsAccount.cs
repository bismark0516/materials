namespace BankTellerExercise.Classes
{
    public class SavingsAccount : BankAccount
    {
        public SavingsAccount(string accountHolderName, string accountNumber) : base(accountHolderName, accountNumber)
        {

        }
        public SavingsAccount(string accountHolderName, string accountNumber, decimal balance) : base(accountHolderName, accountNumber, balance)
        {

        }
        public override decimal Withdraw(decimal amountToWithdraw)
        {
            {
                if (Balance - amountToWithdraw  < 2.00M || amountToWithdraw >Balance)
                {
                    return Balance;
                }
                else if (Balance - amountToWithdraw < 150.00M)
                {
                    base.Withdraw(2.00M + amountToWithdraw);
                }
                else 
                {
                    base.Withdraw(amountToWithdraw);
                }
               
            }
            return Balance;
        }
    }

}



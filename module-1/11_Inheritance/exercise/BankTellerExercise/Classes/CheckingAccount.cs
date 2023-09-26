using BankTellerExercise.Classes;

namespace BankTellerExercise.Classes
{
    public class CheckingAccount : BankAccount
    {
        public CheckingAccount(string accountHolderName, string accountNumber, decimal balance) : base(accountHolderName, accountNumber, balance)
        {

        }
        public CheckingAccount(string accountHolderName, string accountNumber): base(accountHolderName, accountNumber)
        {

        }
        public override decimal Withdraw(decimal amountToWithdraw)
        {
           if(Balance - amountToWithdraw >-100.00M)
            {
                base.Withdraw(amountToWithdraw);
            }
           else
            {
                return Balance;
            }
           if (Balance <0.00m && Balance > -100.00M)
            {
                base.Withdraw(10.00M);
            }
            return Balance;
        }
    }
}


//BankAccount.Balance needs to have a private setter.


//CheckingAccount and SavingsAccount cannot modify Balance directly


//base.Withdraw can be used in CheckingAccount and SavingsAccount to modify the balance

//Determine if the withdrawal is even possible. If it isn’t, leave the method

//Perform the withdrawal for the full amount


//If we are now in fee territory, apply the fee as a separate withdrawal


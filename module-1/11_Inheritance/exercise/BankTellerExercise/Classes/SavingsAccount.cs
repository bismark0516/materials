namespace BankTellerExercise.Classes
{
    public class SavingsAccount: BankAccount
    {
        public SavingsAccount(string accountHolderName, string accountNumber) : base(accountHolderName, accountNumber)
        {

        }
        public SavingsAccount(string accountHolderName, string accountNumber, decimal balance) : base(accountHolderName, accountNumber, balance)
        {

        }
        public override decimal Depoist(decimal amountToDeposit)
        {
            if ()
            {
                base.Deposit(amountToDeposit);
            }
            else
            {
                return Balance;
            }
            if ()
            {
                base.Deposit();
            }
            return Balance;
        }
    }

}
}

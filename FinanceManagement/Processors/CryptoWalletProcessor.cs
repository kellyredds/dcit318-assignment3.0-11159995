namespace FinanceManagement.Processors
{
    public class CryptoWalletProcessor : ITransactionProcessor
    {
        public void Process(Models.Transaction transaction)
        {
            Console.WriteLine($"Crypto Wallet: Deducted {transaction.Amount:C} for {transaction.Category}");
        }
    }
}
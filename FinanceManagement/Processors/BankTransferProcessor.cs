namespace FinanceManagement.Processors
{
    public class BankTransferProcessor : ITransactionProcessor
    {
        public void Process(Models.Transaction transaction)
        {
            Console.WriteLine($"Bank Transfer: Deducted {transaction.Amount:C} for {transaction.Category}");
        }
    }
}
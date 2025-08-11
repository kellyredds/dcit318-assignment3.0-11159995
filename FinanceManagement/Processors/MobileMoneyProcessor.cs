namespace FinanceManagement.Processors
{
    public class MobileMoneyProcessor : ITransactionProcessor
    {
        public void Process(Models.Transaction transaction)
        {
            Console.WriteLine($"Mobile Money: Deducted {transaction.Amount:C} for {transaction.Category}");
        }
    }
}
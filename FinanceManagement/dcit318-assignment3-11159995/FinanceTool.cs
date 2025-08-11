using FinanceManagement.Models;
using FinanceManagement.Processors;

namespace FinanceManagement
{
    public class FinanceTool
    {
        private readonly List<Transaction> _transactions = new();

        public void Run()
        {
            // Creation of account
            var savings = new SavingsAccount("SAV-12345", 900);
            Console.WriteLine($"Start balance: {savings.Balance:C}");

            // Creation of transactions
            var transactions = new List<Transaction>
            {
                new Transaction(1, DateTime.Now, 110.00m, "Groceries"),
                new Transaction(2, DateTime.Now, 120.05m, "Utilities"),
                new Transaction(3, DateTime.Now, 160.00m, "Entertainment")
            };

            // Creation of processes 
            ITransactionProcessor mobileProcessor = new MobileMoneyProcessor();
            ITransactionProcessor bankProcessor = new BankTransferProcessor();
            ITransactionProcessor cryptoProcessor = new CryptoWalletProcessor();

            // Processes of transactions
            mobileProcessor.Process(transactions[0]);
            bankProcessor.Process(transactions[1]);
            cryptoProcessor.Process(transactions[2]);

            // Finally applying to account
            foreach (var t in transactions)
            {
                savings.ApplyTransaction(t);
                _transactions.Add(t);
            }
        }
    }
}
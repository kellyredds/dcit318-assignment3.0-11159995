namespace FinanceManagement.Processors
{
    public interface ITransactionProcessor
    {
        void Process(Models.Transaction transaction);
    }
}
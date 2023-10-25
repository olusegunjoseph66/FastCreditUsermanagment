namespace FastCreditCodingChallange.Repository
{
    public interface IUnitOfWork
    {
       int Commit();
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
        void Rollback();
        void Dispose();
        Task DisposeAsync();
    }
}


using FastCreditCodingChallange.DatabaseModels;

namespace FastCreditCodingChallange.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly FastCreditDbContext _dbContext;
        public UnitOfWork(FastCreditDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public void Rollback()
        {
            _dbContext.Dispose();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task DisposeAsync()
        {
            await _dbContext.DisposeAsync();
            GC.SuppressFinalize(this);
        }

    }
}

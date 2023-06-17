namespace Medics.Repository.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IRoleRepository Roles { get; }
        IUserRepository Users { get; }
        ICategoryRepository Categorys { get; }
        IDrugRepository Drugs { get; }
        IIncomingRepository Incomings { get; }
        IOutgoingRepository Outgoings { get; }
        int SaveChanges();
    }
}

namespace Medics.Repository.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IRoleRepository Roles { get; }
        IUserRepository Users { get; }
        ICategoryRepository Category { get; }
        IAgeRepository Ages { get; }
        ICategoryRepository Categorys { get; }
        IDrugRepository Drugs { get; }
        IIncomingRepository Incomings { get; }
        IOutgoingRepository Outgoings { get; }
        IReturnRepository Returns { get; }  
        int SaveChanges();
    }
}

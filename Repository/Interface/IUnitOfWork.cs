namespace Medics.Repository.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IRoleRepository Roles { get; }
        IUserRepository Users { get; }
        ICategoryRepository Categorys { get; }
        IAgeRepository Ages { get; }
        ICategoriesRepository Categories { get; }
        IDrugRepository Drugs { get; }
        IIncomingRepository Incomings { get; }
        IOutgoingRepository Outgoings { get; }
        IReturnRepository Returns { get; }  
        int SaveChanges();
    }
}

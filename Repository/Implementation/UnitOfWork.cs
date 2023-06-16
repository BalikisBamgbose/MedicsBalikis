using Medics.Context;
using Medics.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Medics.Repository.Implementation
{
    public class UnitOfWork : IUnitOfWork

    {
        private readonly MedicsContext _context;
        private bool _disposed = false;
        public IRoleRepository Roles { get; }
        public  IUserRepository Users { get; }
        public ICategoryRepository Categorys { get; }
        public IAgeRepository Ages { get; }
        public ICategoriesRepository Categories { get; }
        public IDrugRepository Drugs { get; }
        public IIncomingRepository Incomings { get; }
        public IOutgoingRepository Outgoings { get; }
        public IReturnRepository Returns { get; }


        public UnitOfWork(
           MedicsContext context,
           IRoleRepository roleRepository,
           IUserRepository userRepository,
           ICategoryRepository categoryRepository,
           IAgeRepository ageRepository,
           ICategoriesRepository categoriesRepository,
           IDrugRepository drugRepository,
           IIncomingRepository incomingRepository,
           IReturnRepository returnRepository,
           IOutgoingRepository outgoingRepository)
        {
            _context = context;
            Roles = roleRepository;
            Users = userRepository;
            Categorys = categoryRepository;
            Ages = ageRepository;
            Categories = categoriesRepository;
            Drugs = drugRepository;
            Incomings = incomingRepository;
            Outgoings = outgoingRepository;
            Returns = returnRepository;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

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
        public IDrugRepository Drugs { get; }
        public IIncomingRepository Incomings { get; }
        public IOutgoingRepository Outgoings { get; }


        public UnitOfWork(
           MedicsContext context,
           IRoleRepository roleRepository,
           IUserRepository userRepository,
           ICategoryRepository categoryRepository,
           IDrugRepository drugRepository,
           IIncomingRepository incomingRepository,
           IOutgoingRepository outgoingRepository)
        {
            _context = context;
            Roles = roleRepository;
            Users = userRepository;
            Categorys = categoryRepository;
            Drugs = drugRepository;
            Incomings = incomingRepository;
            Outgoings = outgoingRepository;

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

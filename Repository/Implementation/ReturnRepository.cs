using Medics.Context;
using Medics.Entities;
using Medics.Repository.Implementations;
using Medics.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Repository.Implementation
{
    public class ReturnRepository : BaseRepository<Return>, IReturnRepository
    {
        public ReturnRepository(MedicsContext context) : base(context)
        {
        }

        public Return GetReturn(string returnId)
        {
            var Return = _context.Returns
                   .Include(u => u.Name)
                   .Include(c => c.ReturnDate)
                   .Include(q => q.Quantity)
                   .Include(i => i.InvoiceNo)
                   .Include(p => p.Purpose)
                   .Include(sd => sd.SupplyDate)
                   .Include(bv => bv.BillValue)
                   .Include(b => b.Bill)
                   .Include(dd => dd.DeliveryDate)
                   .Include(rn => rn.ReceiptNo)
                   .Include(rb => rb.ReturnedBy)
                   .Where(i => i.Id.Equals(returnId))
                   .FirstOrDefault();

            return Return;
        }

        public List<Return> GetReturns(string returnIds)
        {
            var returns = _context.Returns
                       .Where(i => i.Id.Equals(returnIds))
                       .Include(u => u.Name)
                       .Include(c => c.ReturnDate)
                       .Include(q => q.Quantity)
                       .Include(i => i.InvoiceNo)
                       .Include(p => p.Purpose)
                       .Include(sd => sd.SupplyDate)
                       .Include(bv => bv.BillValue)
                       .Include(b => b.Bill)
                       .Include(dd => dd.DeliveryDate)
                       .Include(rn => rn.ReceiptNo)
                       .Include(rb => rb.ReturnedBy)
                        .ToList();

            return returns;
        }
    }
}

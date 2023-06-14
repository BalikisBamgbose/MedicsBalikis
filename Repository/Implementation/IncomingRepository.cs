using Medics.Context;
using Medics.Entities;
using Medics.Repository.Implementations;
using Medics.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medics.Repository.Implementation
{
    public class IncomingRepository : BaseRepository<Incoming>, IIncomingRepository
    {
        public IncomingRepository(MedicsContext context) : base(context)
        {
        }

        public Incoming GetIncoming(string incomingId)
        {
            var incoming = _context.Incomings
                .Include(u => u.SupplierName)
                .Include(c => c.ItemName)
                .Include(q => q.Quantity)
                .Include(i => i.InvoiceNo)
                .Include(sd => sd.SupplyDate)
                .Include(bv => bv.BillValue)
                .Include(b => b.Bill)
                .Include(dd => dd.DeliveryDate)
                .Include(rn => rn.ReceiptNo)
                .Where(i => i.Id.Equals(incomingId))
                .FirstOrDefault();

            return incoming;
        }

        public List<Incoming> GetIncomings(string incomingIds)
        {
            var incomings = _context.Incomings
                        .Where(i => i.Id.Equals(incomingIds))
                        .Include(u => u.SupplierName)
                        .Include(c => c.ItemName)
                        .Include(q => q.Quantity)
                        .Include(i => i.InvoiceNo)
                        .Include(sd => sd.SupplyDate)
                        .Include(bv => bv.BillValue)
                        .Include(b => b.Bill)
                        .Include(dd => dd.DeliveryDate)
                        .Include(rn => rn.ReceiptNo)
                       .ToList();

            return incomings;
        }
    }
}
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
    public class OutgoingRepository : BaseRepository<Outgoing>, IOutgoingRepository
    {
        public OutgoingRepository(MedicsContext context) : base(context)
        {
        }

        public Outgoing GetOutgoing(string OutgoingId)
        {      
                var Outgoing = _context.Outgoing
                    .Include(u => u.Name)
                    .Include(c => c.Item)
                    .Include(q => q.Quantity)
                    .Include(i => i.InvoiceNo)
                    .Include(p=>p.Purpose)
                    .Include(s => s.Sale)
                    .Include(sd => sd.SupplyDate)
                    .Include(bv => bv.BillValue)
                    .Include(b => b.Bill)
                    .Include(dd => dd.DeliveryDate)
                    .Include(rn => rn.ReceiptNo)
                    .Where(i => i.Id.Equals(OutgoingId))
                    .FirstOrDefault();

                return Outgoing;
            
        }

        public List<Outgoing> GetOutgoings(string OutgoingIds)
        {
            var outgoings = _context.Outgoing
                        .Where(i => i.Id.Equals(OutgoingIds))
                        .Include(u => u.Name)
                        .Include(c => c.Item)
                        .Include(q => q.Quantity)
                        .Include(i => i.InvoiceNo)
                        .Include(p => p.Purpose)
                        .Include(s => s.Sale)
                        .Include(sd => sd.SupplyDate)
                        .Include(bv => bv.BillValue)
                        .Include(b => b.Bill)
                        .Include(dd => dd.DeliveryDate)
                        .Include(rn => rn.ReceiptNo)
                        .ToList();

            return outgoings;
        }
    }
}
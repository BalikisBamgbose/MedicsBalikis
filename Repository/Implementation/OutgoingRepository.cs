using Medics.Context;
using Medics.Entities;
using Medics.Repository.Implementations;
using Medics.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Medics.Repository.Implementation
{
    public class OutgoingRepository : BaseRepository<Outgoing>, IOutgoingRepository
    {
        public OutgoingRepository(MedicsContext context) : base(context)
        {
        }

		public List<Outgoing> GetAllOutgoing(Expression<Func<Outgoing, bool>> expression)
		{
			var outgoings = _context.Outgoing
				 .Where(expression)
				 .Include(s => s.Drug)
				 .ToList();

			return outgoings;
		}

		public Outgoing GetOutgoing(string OutgoingId)
        {      
                var outgoing = _context.Outgoing
                    .Include(u => u.Drug)
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

                return outgoing;
            
        }

        public List<Outgoing> GetOutgoings(string OutgoingIds)
        {
            var outgoings = _context.Outgoing
                        .Where(i => i.Id.Equals(OutgoingIds))
                        .Include(u => u.Drug)
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
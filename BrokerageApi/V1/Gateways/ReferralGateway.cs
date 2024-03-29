using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BrokerageApi.V1.Gateways.Interfaces;
using BrokerageApi.V1.Infrastructure;

namespace BrokerageApi.V1.Gateways
{
    public class ReferralGateway : IReferralGateway
    {
        private readonly BrokerageContext _context;

        public ReferralGateway(BrokerageContext context)
        {
            _context = context;
        }

        public async Task<Referral> CreateAsync(Referral referral)
        {
            var entry = _context.Referrals.Add(referral);
            await _context.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task<IEnumerable<Referral>> GetCurrentAsync(ReferralStatus? status = null)
        {
            if (status == null)
            {
                return await _context.Referrals
                    .Where(r => r.Status != ReferralStatus.Archived)
                    .Where(r => r.Status != ReferralStatus.Approved)
                    .OrderBy(r => r.Id)
                    .ToListAsync();
            }
            else
            {
                return await _context.Referrals
                    .Where(r => r.Status != ReferralStatus.Archived)
                    .Where(r => r.Status != ReferralStatus.Approved)
                    .Where(r => r.Status == status)
                    .OrderBy(r => r.Id)
                    .ToListAsync();
            }
        }

        public async Task<Referral> GetByWorkflowIdAsync(string workflowId)
        {
            return await _context.Referrals
                .Where(r => r.WorkflowId == workflowId)
                .SingleOrDefaultAsync();
        }

        public async Task<Referral> GetByIdAsync(int id)
        {
            return await _context.Referrals
                .Where(r => r.Id == id)
                .SingleOrDefaultAsync();
        }
    }
}

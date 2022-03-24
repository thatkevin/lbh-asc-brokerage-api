using System.Collections.Generic;
using System.Threading.Tasks;
using BrokerageApi.V1.Infrastructure;

namespace BrokerageApi.V1.Gateways.Interfaces
{
    public interface IReferralGateway
    {
        public Task<Referral> CreateAsync(Referral referral);
        public Task<IEnumerable<Referral>> GetCurrentAsync();
        public Task<Referral> GetByWorkflowIdAsync(string workflowId);
    }
}
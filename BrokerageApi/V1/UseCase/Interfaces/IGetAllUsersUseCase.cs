using System.Collections.Generic;
using System.Threading.Tasks;
using BrokerageApi.V1.Infrastructure;

namespace BrokerageApi.V1.UseCase.Interfaces
{
    public interface IGetAllUsersUseCase
    {
        public Task<IEnumerable<User>> ExecuteAsync(UserRole? role = null);
    }
}

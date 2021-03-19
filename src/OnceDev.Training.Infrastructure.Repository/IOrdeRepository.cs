using OnceDev.Training.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnceDev.Training.Infrastructure.Repository
{
    public interface IOrdeRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> ListWithOrderItemAsync();
    }
}

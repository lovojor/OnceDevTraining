using Microsoft.EntityFrameworkCore;
using OnceDev.Training.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnceDev.Training.Infrastructure.Repository
{
    public class OrderRepository : Repository<Order>, IOrdeRepository
    {
        public OrderRepository(NorthwindDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Order>> ListWithOrderItemAsync()
        {
            return await _context.Orders.Include(o => o.OrderItems).ToListAsync();
        }

    }
}

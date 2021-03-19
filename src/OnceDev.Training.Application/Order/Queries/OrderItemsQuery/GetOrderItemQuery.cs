using MediatR;
using OnceDev.Training.Infrastructure.Repository;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OnceDev.Training.Application.Order.Queries.OrderItemsQuery
{
    public class GetOrderItemQuery: IRequest<IEnumerable<Domain.Order>>
    {
    }

    public class GetOrderItemHandler:IRequestHandler<GetOrderItemQuery, IEnumerable<Domain.Order>>
    {
        private readonly IOrdeRepository _repository;

        public GetOrderItemHandler(IOrdeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Domain.Order>> Handle(GetOrderItemQuery request, CancellationToken cancellationToken)
        {
            var res = await _repository.ListWithOrderItemAsync();
            return res;
        }
    }
}

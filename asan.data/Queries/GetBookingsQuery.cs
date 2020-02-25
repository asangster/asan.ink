using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace asan.data.Queries
{
    public class GetBookingsQuery : IRequest<IEnumerable<Booking>>
    {
        public GetBookingsQuery(int? id = null)
        {
            Id = id;
        }

        public int? Id { get; }
    }

    public class GetBookingsQueryHandler: IRequestHandler<GetBookingsQuery, IEnumerable<Booking>>
    {
        private readonly InkContext _context;

        public GetBookingsQueryHandler(InkContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Booking>> Handle(GetBookingsQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Bookings;
            if(request.Id is object)
            {
                query.Where(w=> w.Id == request.Id.Value);
            }
            var result = query.ToList();

            return Task.FromResult(result.AsEnumerable());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace asan.data.Commands
{
    public class AddBookingCommand : IRequest
    {
        public string Name { get; set; }
        public string Overview { get; set; }
    }

    public class AddBookingCommandHandler : RequestHandler<AddBookingCommand>
    {
        private readonly InkContext _context;

        public AddBookingCommandHandler(InkContext context)
        {
            _context = context;
        }

        protected override void Handle(AddBookingCommand request)
        {
            var booking = new Booking()
            {
                ArtistName = request.Name,
                Overview = request.Overview
            };
            _context.Bookings.AddAsync(booking);
            _context.SaveChanges();
        }
    }
}

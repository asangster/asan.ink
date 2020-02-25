using asan.data.Queries;
using asan.ink.tests.ZeroFriction;
using MediatR;
using NUnit.Framework;
using System.Linq;

namespace asan.ink.tests
{
    public class Tests
    {
        private IMediator _mediator;
        [SetUp]
        public void Setup()
        {
            _mediator = DependencyResolverHelpers.GetService<IMediator>();
        }

        [Test]
        public void GetBookings_Doesnt_Explode()
        {
          

            var results = _mediator.Send(new GetBookingsQuery());

        }



        [Test]
        public void GetBookings_Returns_Stuff()
        {
            var mediator = DependencyResolverHelpers.GetService<IMediator>();
            var bookings = mediator.Send(new GetBookingsQuery()).Result;


            Assert.IsTrue(bookings.Any());
        }
    }
}
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

// All this logic was already inside our controller, but the logic has moved to our application project and 
// were gonna refactor our activities controller to get the activities from this query
namespace Application.Activities
{
    public class List
    {
        // Use a Mediator interface, IRequest, and specify the type of thing were returning (list of our activities)
        public class Query : IRequest<List<Activity>> { } // If there were any parameters we had to pass they'd go in as class properties, but there aren't any when returning a list

        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Activities.ToListAsync();
            }
        }
    }
}
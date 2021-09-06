using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Create
    {
        public class Command : IRequest
        {
            // What were receiving as a parameter from our API
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext __context;
            public Handler(DataContext _context)
            {
                __context = _context;
            }

            // This method is technically returning a Task<Unit> (Unit from Mediator)
            // Basically like returning nothing, but it tells our API our request is finished
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                __context.Activities.Add(request.Activity);
                // we don't use async bc were not touching the database..
                // only adding to memory

                await __context.SaveChangesAsync(); // This is where the change is added
                return Unit.Value; // equivalent to nothing
            }
        }
    }
}
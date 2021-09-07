using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Delete
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext __context;
            public Handler(DataContext _context)
            {
                __context = _context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await __context.Activities.FindAsync(request.Id);

                __context.Remove(activity); // removes from memory

                await __context.SaveChangesAsync();
                return Unit.Value;

            }
        }
    }
}
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Edit
    {
        public class Command : IRequest
        {

            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext __context;
            private readonly IMapper _mapper;
            public Handler(DataContext _context, IMapper mapper)
            {
                _mapper = mapper;
                __context = _context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await __context.Activities.FindAsync(request.Activity.Id);

                _mapper.Map(request.Activity, activity);

                await __context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
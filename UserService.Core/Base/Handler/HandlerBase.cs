using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace UserService.Core.Base.Handler
{
    public abstract class HandlerBase<TInput, TResult> : IRequestHandler<TInput, TResult>
        where TInput : IRequest<TResult>
    {
        protected DbContext DbContext { get; }
        protected IMapper Mapper { get; }

        protected HandlerBase(/*DbContext dbContext,*/ IMapper mapper)
        {
            //DbContext = dbContext;
            Mapper = mapper;
        }

        public abstract Task<TResult> Handle(TInput request, CancellationToken cancellationToken);
    }

    public abstract class HandlerBase<TInput> : IRequestHandler<TInput>
        where TInput : IRequest
    {
        protected DbContext DbContext { get; }
        protected IMapper Mapper { get; }

        protected HandlerBase(/*DbContext dbContext,*/ IMapper mapper)
        {
            //DbContext = dbContext;
            Mapper = mapper;
        }

        public abstract Task<Unit> Handle(TInput request, CancellationToken cancellationToken);
    }
}
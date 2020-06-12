using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BioWorld.Application.Common.Interface;
using MediatR;

namespace BioWorld.Application.Category.Queries.ListCategory
{
    public class ListCategoryQuery : IRequest<IEnumerable<PostListItem>>
    {
    }

    public class GetListCategoryHandler : IRequestHandler<ListCategoryQuery, IEnumerable<PostListItem>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetListCategoryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<IEnumerable<PostListItem>> Handle(ListCategoryQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
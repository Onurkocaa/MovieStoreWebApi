using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.Application.DirectorOperations.Queries.GetDirectors
{
    public class GetDirectorQuery
    {
        public DirectorViewModel Model { get; set; }

        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetDirectorQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<DirectorViewModel> Handle()
        {
            var director = _context.Directors.OrderBy(x => x.Id).ToList<Director>();

            List<DirectorViewModel> result = _mapper.Map<List<DirectorViewModel>>(director);

            return result;

        }
        public class DirectorViewModel
        {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FilmsDirected { get; set; }
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.Application.ActorOperations.Queries.GetActors
{
    public class GetActorsQuery
    {
        public ActorViewModel Model { get; set; }

        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetActorsQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<ActorViewModel> Handle()
        {
            var actors = _context.Actors.OrderBy(x => x.Id).ToList<Actor>();

            List<ActorViewModel> result = _mapper.Map<List<ActorViewModel>>(actors);

            return result;

        }
    }
    public class ActorViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PlayedMovies { get; set; }
    }
}
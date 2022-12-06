using System;
using System.Linq;
using AutoMapper;
using MovieStoreWebApi.DBOperations;

namespace Application.ActorOperations.Queries.GetActorDetail
{
    public class GetActorDetailQuery
    {
        public int ActorId { get; set; }
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetActorDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ActorDetailModel Handle() 
        {
            var actors = _context.Actors.SingleOrDefault(x => x.Id == ActorId);

            if (actors is null)
             throw new InvalidOperationException("Oyuncu bulunamadı!");

            ActorDetailModel model = _mapper.Map<ActorDetailModel>(actors);
            return model;
        }
    }
     public class ActorDetailModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PlayedMovies { get; set; }
    }
}
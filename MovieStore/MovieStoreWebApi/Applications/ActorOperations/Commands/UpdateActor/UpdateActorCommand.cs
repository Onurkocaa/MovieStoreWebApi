using System;
using System.Linq;
using AutoMapper;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.Application.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommand
    {
        public UpdateActorModel Model { get; set; }
        public int ActorId { get; set; }
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public UpdateActorCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var actor = _context.Actors.SingleOrDefault(x => x.Id == ActorId);

            if (actor is not null)
                throw new InvalidOperationException("Oyuncu bulunamadı.");

            _mapper.Map<UpdateActorModel,Actor>(Model,actor);

            _context.Actors.Update(actor);
            _context.SaveChanges();
        }
    }
        public class UpdateActorModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PlayedMovies { get; set; }
    }
}
    
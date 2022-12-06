using System;
using System.Linq;
using AutoMapper;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace Application.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommand
    {
        public UpdateMovieModel Model { get; set; }
        public int MovieId { get; set; }

        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public UpdateMovieCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle() 
        {
            var movie = _context.Movies.SingleOrDefault(x => x.ID == MovieId);

            if (movie is null) 
            throw new InvalidOperationException("Film Bulunamadı !");
             

            _mapper.Map<UpdateMovieModel, Movie>(Model, movie);

            _context.Movies.Update(movie);
            _context.SaveChanges();
        }

    }

   public class UpdateMovieModel
    {
        public int GenreID { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public int Price { get; set; }
        public bool IsActive { get; set; }

    }
}
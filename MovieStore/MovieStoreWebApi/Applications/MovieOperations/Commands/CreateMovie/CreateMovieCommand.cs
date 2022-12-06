using System;
using MovieStoreWebApi.DBOperations;
using AutoMapper;
using System.Linq;
using MovieStoreWebApi.Entities;

namespace Applications.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommand
    {
        public CreateMovieModel Model{get; set;}
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateMovieCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var movie=_context.Movies.SingleOrDefault(x=>x.Title==Model.Title);
            if(movie is not null)
            throw new InvalidOperationException("Film zaten mevcut!");
            movie = _mapper.Map<Movie>(Model);
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }
    }
    public class CreateMovieModel
    {
        public int GenreID { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public int Price { get; set; }
    }
}
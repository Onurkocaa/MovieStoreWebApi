using System;
using System.Linq;
using MovieStoreWebApi.DBOperations;

namespace Applications.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovieCommand
    {
        private readonly IMovieStoreDbContext _context;
        public int MovieId {get;set;}
        public DeleteMovieCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var movie = _context.Movies.SingleOrDefault(x=>x.ID==MovieId);
            if(movie is null)
            throw new InvalidOperationException("Aradığınız film bulunamadı!");
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
    }
}
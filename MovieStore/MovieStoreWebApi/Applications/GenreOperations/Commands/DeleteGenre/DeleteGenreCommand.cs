using System;
using System.Linq;
using MovieStoreWebApi.DBOperations;

namespace Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        public int GenreID { get; set; }

        private readonly IMovieStoreDbContext _context;

        public DeleteGenreCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreID);

            if (genre is null)
            throw new InvalidOperationException("Film türü  Bulunamadı ! ");

            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }

    }
}
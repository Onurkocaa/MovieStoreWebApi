using System;
using System.Linq;
using AutoMapper;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {

        public UpdateGenreModel Model { get; set; }
        public int GenreID { get; set; }

        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public UpdateGenreCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreID);

            if (genre is null)
             throw new InvalidOperationException("Film türü Bulunamadı !");
            if(_context.Genres.Any(x=>x.Name.ToLower() == Model.Name.ToLower()&& x.Id !=GenreID))
            throw new InvalidOperationException("Aynı isimli film türü zaten mevcut");
            _mapper.Map<UpdateGenreModel, Genre>(Model, genre);

            _context.Genres.Update(genre);
            _context.SaveChanges();
        }
    }

    public class UpdateGenreModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
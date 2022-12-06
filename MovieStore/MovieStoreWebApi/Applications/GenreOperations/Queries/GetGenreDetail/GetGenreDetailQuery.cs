using System;
using System.Linq;
using AutoMapper;
using MovieStoreWebApi.DBOperations;

namespace Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        public int GenreId { get; set; }
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetGenreDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GenreDetailModel Handle() 
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);

            if (genre is null)
             throw new InvalidOperationException("Film Türü bulunamadı ! ");

            GenreDetailModel model = _mapper.Map<GenreDetailModel>(genre);
            return model;
        }
    }
    public class GenreDetailModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
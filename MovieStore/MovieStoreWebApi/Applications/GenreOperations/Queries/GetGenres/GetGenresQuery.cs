using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace Application.GenreOperations.Queries.GetGenres
{
    public class GetGenresQuery
    {
        public GetViewModel Model { get; set; }

        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetGenresQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetViewModel> Handle()
        {
            var genres = _context.Genres.Where(x => x.IsActive == true).ToList<Genre>();

            var returnObj = _mapper.Map<List<GetViewModel>>(genres);

            return returnObj;

        }
    }
    public class GetViewModel
    {
        public string Name { get; set; }
    }
}
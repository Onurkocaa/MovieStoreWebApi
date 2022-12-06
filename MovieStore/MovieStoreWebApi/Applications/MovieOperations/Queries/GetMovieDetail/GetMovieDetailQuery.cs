using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.DBOperations;

namespace Applications.MovieOperations.Queries.GetMovieDetail
{
    public class GetMovieDetailQuery
    {
      private readonly IMovieStoreDbContext _context;
      private readonly IMapper _mapper;
      public int MovieId{get;set;}
      public GetMovieDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
       public MovieDetailModel Handle()
       {
        var movie =_context.Movies.Include(x => x.Genre).Where(movie => movie.ID == MovieId).SingleOrDefault();
        if(movie is null)
        throw new InvalidOperationException("Film bulunamadı!");
        MovieDetailModel vm =_mapper.Map<MovieDetailModel>(movie);
        return vm;
       }
    }
    public class MovieDetailModel
    {
        public string Genre { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Director { get; set; }
        public string Players { get; set; }
        public int Price { get; set; }
    }
}
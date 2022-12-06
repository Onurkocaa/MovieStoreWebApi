using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace Applications.MovieOperations.Queries.GetMovies
{
    public class GetMovieQuery
    {
     private readonly IMovieStoreDbContext _context;
     private readonly IMapper _mapper;
        public GetMovieQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<MovieViewModel> Handle()
        {
            var movieList = _context.Movies.Include(x=> x.Genre).OrderBy(x=>x.ID).ToList<Movie>();
            List<MovieViewModel> returnobj = _mapper.Map<List<MovieViewModel>>(movieList);
            return returnobj;
        }
    }
        public class MovieViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Price { get; set; }
    }
}
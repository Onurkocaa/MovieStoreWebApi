using System;
using System.Linq;
using AutoMapper;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.Application.DirectorOperations.Queries.GetDirectorDetail
{
    public class GetDirectorDetailQuery
    {
    public int DirectorId { get; set; }
    private readonly IMovieStoreDbContext _context;
    private readonly IMapper _mapper;

    public GetDirectorDetailQuery(IMovieStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public DirectorDetailModel Handle()
    {
        var director = _context.Directors.SingleOrDefault(x => x.Id == DirectorId);

        if (director is null)
        throw new InvalidOperationException("Yönetmen bulunamadı!");

        var result = _mapper.Map<DirectorDetailModel>(director);
        return result;
    }
    }
    public class DirectorDetailModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FilmsDirected { get; set; }
    }
}

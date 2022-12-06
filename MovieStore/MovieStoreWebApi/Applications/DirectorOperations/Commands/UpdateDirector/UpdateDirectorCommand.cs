using System;
using System.Linq;
using AutoMapper;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.Application.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommand
    {
        public UpdateDirectorModel Model { get; set; }
        public int DirectorId { get; set; }
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public UpdateDirectorCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var director = _context.Directors.SingleOrDefault(x => x.Id == DirectorId);

            if (director is null)
            {
                throw new InvalidOperationException("Yönetmen Bulunamadı!");
            }
            _mapper.Map<UpdateDirectorModel, Director>(Model, director);

            _context.Directors.Update(director);
            _context.SaveChanges();
        }
    }
    public class UpdateDirectorModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FilmsDirected { get; set; }
    }
}
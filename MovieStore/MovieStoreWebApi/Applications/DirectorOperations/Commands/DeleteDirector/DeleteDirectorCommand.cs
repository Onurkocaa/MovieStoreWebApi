using System;
using System.Linq;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.Application.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommand
    {
    public int DirectorId { get; set; }
    private readonly IMovieStoreDbContext _context;
    public DeleteDirectorCommand(IMovieStoreDbContext context)
    {
    _context = context;
    }
    public void Handle()
    {
    var director = _context.Directors.SingleOrDefault(x => x.Id == DirectorId);

    if (director is null)
    throw new InvalidOperationException("Yönetmen Bulunamadı!");

    _context.Directors.Remove(director);
    _context.SaveChanges();
    }
    }
}
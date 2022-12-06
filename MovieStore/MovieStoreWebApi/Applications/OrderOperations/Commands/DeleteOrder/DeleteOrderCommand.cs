using System;
using System.Linq;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.Application.OrderOperations.Commands.DeleteOrder
{
    public class DeleteOrderCommand
    {
         public int OrderId;
         private readonly IMovieStoreDbContext _context;

         public DeleteOrderCommand(IMovieStoreDbContext context)
         {
            _context = context;
         }
         public void Handle()
         {
            var order = _context.Orders.SingleOrDefault(s => s.Id == OrderId);

            if (order is null)
                throw new InvalidOperationException("Kayıt bulunamadı!");

            _context.Orders.Update(order);
            _context.SaveChanges();
         }
 
    }
}
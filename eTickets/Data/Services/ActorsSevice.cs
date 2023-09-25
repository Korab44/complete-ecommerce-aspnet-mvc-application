using eTickets.Data.Base;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace eTickets.Data.Services
{
    public class ActorsSevice : EntityBaseRepository<Actor>, IActorsService
    {
        private readonly AppDbContext _context;
        public ActorsSevice(AppDbContext context): base(context) { }
     
    
    }
}

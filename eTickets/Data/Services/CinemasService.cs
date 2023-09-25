using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public class CinemasService: EntityBaseRepository<Cinema>, ICinemaServis
    {
        public CinemasService(AppDbContext context) : base(context)
        { 
        
        } 
    }
}

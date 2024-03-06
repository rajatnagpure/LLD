using ParkingLot.Models;

namespace ParkingLot.Repositories
{
    public class TicketRepository
    {
        private Dictionary<long, Ticket> Tickets = new Dictionary<long, Ticket>();
        public long IdCount = 0;

        public long Save(Ticket ticket)
        {
            Tickets[IdCount++] = ticket;
            return IdCount - 1;
        }

        public Ticket? GetTicketById(long id)
        {
            if (!Tickets.ContainsKey(id)) return null;
            return Tickets[id];
        }
    }
}


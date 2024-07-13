using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba1.Models
{
    public class EventoDetalle
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string EventImage { get; set; }
        public DateTime EventDate { get; set; }
        public string EventLocation { get; set; }
        public string EventDescription { get; set; }
        public decimal TicketPrice { get; set; }
    }
}

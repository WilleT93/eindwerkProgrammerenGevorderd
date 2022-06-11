using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservatie.BL.Domein
{
    internal class Reservatie
    {
        public int Id { get; private set; }
        public DateTime ReservatieDatum { get; private set; }
        //public Toestel toestel { get; private set; }
        //public List<Tijdslot> GereserveerdTijdslot { get; private set; }
        public Dictionary<int, int> Sessies = new Dictionary<int, int>();// <key=TijdslotId , value=ToestelId>
        public void ZetId(int id)
        {
            this.Id=id;
        }
        public void ZetReservatieDatum (DateTime reservatiedatum)
        {
            this.ReservatieDatum = reservatiedatum;
        }

    }
}

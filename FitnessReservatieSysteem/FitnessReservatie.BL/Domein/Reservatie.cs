using FitnessReservatie.BL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservatie.BL.Domein
{
    public class Reservatie
    {

        public int Id { get; private set; }
        public DateTime ReservatieDatum { get; private set; }
        //public Toestel toestel { get; private set; }
        //public List<Tijdslot> GereserveerdTijdslot { get; private set; }
        public Klant klant;
        private Dictionary<int, int> Sessies = new Dictionary<int, int>();// <key=TijdslotId , value=ToestelId>

        public Reservatie(int id , DateTime ReservatieDatum, Klant klant)
        {
            ZetId(id);
            ZetReservatieDatum(ReservatieDatum);
            ZetKlant(klant);
        }

        public void ZetId(int id)
        {
            this.Id=id;
        }
        public void ZetReservatieDatum (DateTime reservatiedatum)
        {
            this.ReservatieDatum = reservatiedatum;
        }
        public void ZetKlant(Klant klant)
        {
            if (klant == null)
            {
                throw new ReservatieException("ZetKlant");
            }
            this.klant = klant;
        }
        public void VoegSessieToe(int TijdslotId , int ToestelId)
        {
            if ( Sessies.ContainsKey(TijdslotId))
            {
                throw new ReservatieException("VoegSessieToe");
            }
            Sessies.Add(TijdslotId, ToestelId);
            
        }

    }
}

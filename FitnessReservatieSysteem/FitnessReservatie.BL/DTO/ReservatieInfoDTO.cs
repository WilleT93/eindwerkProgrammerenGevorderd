using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservatie.BL.DTO
{
    public class ReservatieInfoDTO
    {
        public ReservatieInfoDTO(DateTime reservatieDatum, string reservatieSlot, string reservatieToestel)
        {
            ReservatieDatum = reservatieDatum;
            ReservatieSlot = reservatieSlot;
            ReservatieToestel = reservatieToestel;
        }

        public DateTime ReservatieDatum {get; private set; }
        public string ReservatieSlot { get; private set; }
        public string ReservatieToestel { get; private set; }

        public override string ToString()
        {
            return $"{this.ReservatieDatum.Day}/{this.ReservatieDatum.Month}/{this.ReservatieDatum.Year}| {this.ReservatieSlot}| {this.ReservatieToestel}";
        }
       
    }
}

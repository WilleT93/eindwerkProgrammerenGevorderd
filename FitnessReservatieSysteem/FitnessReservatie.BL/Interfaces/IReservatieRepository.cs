using FitnessReservatie.BL.Domein;
using FitnessReservatie.BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservatie.BL.Interfaces
{
    public interface IReservatieRepository
    {
        IReadOnlyList<ReservatieInfoDTO> ZoekReservatie(int id);
        int? ZoekReservatieId(int klantId, DateTime reservatieDatum);
        int SchrijfReservatieIndDB(int klantId, DateTime reservatieDatum);
        void SchrijfReservatieDetailsInDB(int reservatieId, int toestelId, int tijdslotId);
        //int WijsToestelToe(DateTime date, string type, string timeslot);
        IReadOnlyList<int> ZoekBruikbareToestellen(DateTime date, string type, int tijdslotId);
    }
}

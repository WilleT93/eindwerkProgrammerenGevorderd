using FitnessReservatie.BL.Domein;
using FitnessReservatie.BL.DTO;
using FitnessReservatie.BL.Exceptions;
using FitnessReservatie.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservatie.BL.Managers
{
    public class ReservatieManager
    {
        private IReservatieRepository repo;

        public ReservatieManager(IReservatieRepository repo)
        {
            this.repo = repo;
        }
        public IReadOnlyList<ReservatieInfoDTO> ZoekReservatie (int id)
        {
            if (id <= 0)
            {
                throw new ReservatieManagerException("ZoekReservatie - geen geldige ID.");
            }
            return repo.ZoekReservatie(id);
        }
        public void MaakReservatie(int klantId, DateTime? reservatieDatum, int? tijdslotId, string toestelType)
        {
            try
            {
            if (reservatieDatum < DateTime.Today.AddDays(1) || reservatieDatum > DateTime.Today.AddDays(7))
            {
                throw new ReservatieManagerException("Enkel dagen toegelaten die maximaal 7dagen in de toekomst vallen");
            }
                int reservatieID = this.SchrijfReservatieInDB(klantId, (DateTime)reservatieDatum);
                int toestelID = this.WijsToestelToe((DateTime)reservatieDatum, toestelType,(int)tijdslotId);

                this.SchrijfReservatieDetailsInDB(reservatieID,toestelID,(int)tijdslotId);
            }
            catch (Exception ex)
            {
                throw new ReservatieManagerException("MaakReservatie", ex);
                
            }


        }
        public int SchrijfReservatieInDB(int KlantId, DateTime reservatieDatum)
        {
            if (KlantId <= 0)
            {
                throw new ReservatieManagerException("SchrijfReservatieInDB");
            }
            return repo.SchrijfReservatieIndDB(KlantId, reservatieDatum);
        }
        public void SchrijfReservatieDetailsInDB(int reservatieId, int ToestelId, int TijdslotId)
        {
            if (reservatieId <= 0 || ToestelId <= 0 || TijdslotId <= 0 )
            {
                throw new ReservatieManagerException("ZoekReservatieId");
            }
            repo.SchrijfReservatieDetailsInDB(reservatieId,ToestelId,TijdslotId);
        }
        public int? ZoekReservatieId(int reservatieId, DateTime reservatieDatum)
        {
            if (reservatieId <= 0)
            {
                throw new ReservatieManagerException("ZoekReservatieId");
            }
            return repo.ZoekReservatieId(reservatieId, reservatieDatum);
        }
        public int WijsToestelToe(DateTime date, string type, int tijdslotId )
        {
            IReadOnlyList<int> toestelIDs = repo.ZoekBruikbareToestellen(date, type, tijdslotId);
            Random r = new Random();
            int index = r.Next(toestelIDs.Count);
            return toestelIDs[index];

            //return repo.WijsToestelToe(date, type, timeslot);
        }


    }
}

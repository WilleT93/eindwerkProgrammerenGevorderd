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
        //public void MaakReservatie(int klantId, DateTime reservatieDatum, int tijdslotId, string toestelType)
        //{
        //    try
        //    {
        //        int reservatieID = this.SchrijfReservatieInDB(klantId,reservatieDatum);
        //        this.SchrijfReservatieDetailsInDB();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ReservatieManagerException("MaakReservatie", ex);
        //    }


        //}
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


    }
}

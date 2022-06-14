using FitnessReservatie.BL.Domein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservatie.BL.Interfaces
{
    internal interface IReservatieRepository
    {
        public Reservatie GetReservatie(int id, string email);
        public Reservatie GetReservatieDetails(int id, string email); 


    }
}

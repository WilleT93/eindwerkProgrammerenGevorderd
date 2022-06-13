using FitnessReservatie.BL.Domein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservatie.BL.Interfaces
{
    internal interface IKlantRepository
    {
        public Klant ZoekKlantOpId(int id);
        public Klant ZoekKlantOpEmail(string email);
    }
}

using FitnessReservatie.BL.Domein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservatie.BL.Interfaces
{
    public interface IKlantRepository
    {
        //public Klant ZoekKlantOpId(int id);
        //public Klant ZoekKlantOpEmail(string email);
         string ZoekKlantVoornaam(int? id,string email);
         Klant ZoekKlantDetails(int ? id,string email);

    }
}

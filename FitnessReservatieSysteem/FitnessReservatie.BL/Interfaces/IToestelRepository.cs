using FitnessReservatie.BL.Domein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservatie.BL.Interfaces
{
    public interface IToestelRepository
    {
        public IReadOnlyList<string> KiesToestel();
        IReadOnlyList<Toestel> ZoekAlleToestellen();
        IReadOnlyList<Toestel> ZoekToestellenVanType(string selectedItem);
        void VerwijderToestel(int toestelID);
        void ZetToeselBeschikbaar(int id);
        void ZetToestelOnbeschikbaar(int id);
    }
}

using FitnessReservatie.BL.Domein;
using FitnessReservatie.BL.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservatie.BL.Managers
{
     public class ToestelManager
    {
        private IToestelRepository repo;

        public ToestelManager(IToestelRepository repo)
        {
            this.repo = repo;
        }
        public IReadOnlyList<string> KiesToestel()
        {
            return repo.KiesToestel();
        }
        public IReadOnlyList<Toestel> ZoekAlleToestellen()//todo check fouten
        {
            return repo.ZoekAlleToestellen();
        }

        public IReadOnlyList<Toestel> ZoekAlleToestellenVanType(string selectedItem)
        {
            return repo.ZoekToestellenVanType(selectedItem);
        }

        public void VerwijderToestel(int toestelID)
        {
            repo.VerwijderToestel(toestelID);
        }

        public void MaakToestelBeschikbaar(int id)
        {
            repo.ZetToeselBeschikbaar(id);
        }

        public void MaakToestelOnbeschikbaar(int id)
        {
            repo.ZetToestelOnbeschikbaar(id);
        }
    }
}

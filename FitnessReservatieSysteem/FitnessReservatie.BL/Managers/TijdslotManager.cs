using FitnessReservatie.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservatie.BL.Managers
{
    public class TijdslotManager
    {
        private ITijdslotRepository repo;

        public TijdslotManager(ITijdslotRepository repo)
        {
            this.repo = repo;
        }
        public IReadOnlyList<string> KiesTijdslot()
        {
        return repo.KiesTijdslot();
        }
    }
   
}

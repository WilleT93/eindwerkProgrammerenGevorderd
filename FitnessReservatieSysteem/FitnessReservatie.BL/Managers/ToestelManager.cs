using FitnessReservatie.BL.Interfaces;
using System;
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservatie.BL.Domein
{
    internal class Tijdslot
    {
        public Tijdslot(int id)
        {
            ZetId(Id);
        }

        public int Id { get;private set; }
        public void ZetId(int Id)
        {
            this.Id = Id;
        }
    }
    
}

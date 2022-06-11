using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservatie.BL.Domein
{
    public class Tijdslot
    {
        public Tijdslot(int id)
        {
            ZetId(id);
        }

        public int Id { get;private set; }
        public void ZetId(int id)
        {
            this.Id = id;
        }
    }
    
}

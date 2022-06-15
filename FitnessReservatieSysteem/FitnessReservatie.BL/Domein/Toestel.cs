using FitnessReservatie.BL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservatie.BL.Domein
{
    public class Toestel
    {
        public Toestel(int id, string type,bool beschikbaarheid)
        {
            ZetId(id);
            ZetType(type);
            ZetBeschikbaarheid(beschikbaarheid);
           
        }
        private void ZetBeschikbaarheid(bool beschikbaarheid)
        {
            this.IsBeschikbaar = beschikbaarheid;
        }

        public int Id { get; private set; }
        public string Type { get; private set; }
        public bool IsBeschikbaar{ get; set; }

        public void ZetId (int id)
        {
           this.Id = id;
        }
        public void ZetType (string type)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                throw new KlantException("ZetType");
            }
            this.Type = type;
        }
        public override string ToString()
        {
            string beschikbaarheid;
            if (this.IsBeschikbaar)
            {
                beschikbaarheid = "beschikbaar";
            }
            else
            {
                beschikbaarheid = "niet beschikbaar";
            }
            return $"{this.Id}-{this.Type}-{beschikbaarheid}";
        }

    }
}

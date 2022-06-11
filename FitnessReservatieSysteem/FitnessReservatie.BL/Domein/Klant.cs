using FitnessReservatie.BL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservatie.BL.Domein
{
    public class Klant
    {
        public int Id { get; private set; }
        public string Email { get; private set; }
        public string Voornaam { get; private set; }
        public string Achternaam { get; private set; }

        public void ZetId(int id)
        {
            if (id <= 0)
            {
                throw new KlantException("ZetId.");
            } 
            this.Id = id; 
        }
        public void ZetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new KlantException("ZetEmail");
            }
            this.Email = email;
        }

    }
}

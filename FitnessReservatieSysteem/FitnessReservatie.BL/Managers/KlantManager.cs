using FitnessReservatie.BL.Domein;
using FitnessReservatie.BL.Exceptions;
using FitnessReservatie.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservatie.BL.Managers
{
    internal class KlantManager
    {
        public KlantManager(IKlantRepository klantRepository)
        {
            this.repo = klantRepository;
        }
        private IKlantRepository repo;
        public Klant ZoekKlantOpId(int id)
        {
            if (id <= 0)
            {
                throw new KlantManagerException("ZoekKlantOpId");
            }
            return repo.ZoekKlantOpId(id);
        }
        public Klant ZoekKlantOpEmail(string email)
        {
            return repo.ZoekKlantOpEmail(email);
        }

    }
}


//(!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))

﻿using FitnessReservatie.BL.Domein;
using FitnessReservatie.BL.Exceptions;
using FitnessReservatie.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservatie.BL.Managers
{
    public class KlantManager
    {
        private IKlantRepository repo;
        public KlantManager(IKlantRepository klantRepository)
        {
            this.repo = klantRepository;
        }
        public string GetKlantVoornaam(int? id, string email)
        {
            return repo.ZoekKlantVoornaam(id, email); 
        }
        public Klant ZoekKlantDetails(int? id, string email)
        {
            return repo.ZoekKlantDetails(id, email);
        }

        //public Klant ZoekKlantOpId(int id)
        //{
        //    if (id <= 0)
        //    {
        //        throw new KlantManagerException("ZoekKlantOpId");
        //    }
        //    return repo.ZoekKlantOpId(id);
        //}
        //public Klant ZoekKlantOpEmail(string email)
        //{
        //    return repo.ZoekKlantOpEmail(email);
        //}

    }
}


//(!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FItnessReservatieDL.Exeptions
{
    public class KlantRepoADOException : Exception
    {
        public KlantRepoADOException(string message) : base(message)
        {

        }
        public KlantRepoADOException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }   
}

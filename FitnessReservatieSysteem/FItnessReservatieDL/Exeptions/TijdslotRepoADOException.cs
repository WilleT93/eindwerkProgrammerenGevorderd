using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FItnessReservatieDL.Exeptions
{
    internal class TijdslotRepoADOException : Exception
    {
        public TijdslotRepoADOException (string? message) : base(message)
        {

        }
        public TijdslotRepoADOException(string? message, Exception? innerException) :  base(message, innerException)
        {

        }
    }
}

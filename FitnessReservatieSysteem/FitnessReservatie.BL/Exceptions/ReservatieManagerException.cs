using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservatie.BL.Exceptions
{
    internal class ReservatieManagerException : Exception
    {
        public ReservatieManagerException(string message) : base(message)
        {

        }
        public ReservatieManagerException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}

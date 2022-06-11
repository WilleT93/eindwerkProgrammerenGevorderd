using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservatie.BL.Exceptions
{
    internal class ReservatieException : Exception
    {
        public ReservatieException(string message) : base (message)
        {
            //Console.WriteLine(message);
        }
        public ReservatieException(string message , Exception innerException) : base (message , innerException)
        {

        }
    }
}

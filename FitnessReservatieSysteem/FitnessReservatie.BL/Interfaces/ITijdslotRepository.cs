﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessReservatie.BL.Interfaces
{
    public interface ITijdslotRepository
    {
        IReadOnlyList<string> KiesTijdslot();
    }
}

﻿using FudSpin.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudSpin.ServiceManagers.SpinnerDetailSelectionManagers
{
    public interface ISpinnerDetailSelectionManager
    {
        Task<List<SpinnerDetailSelection>> GetAllSelections();
    }
}

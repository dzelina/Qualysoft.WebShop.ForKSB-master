﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qualysoft.WebShop.ForKSB.Services
{
    public interface IApiService
    {
        object CallBPM(string mobile, string zip, string street);
    }
}

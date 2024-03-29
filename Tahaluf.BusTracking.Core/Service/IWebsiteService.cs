﻿using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.BusTracking.Core.Data;

namespace Tahaluf.BusTracking.Core.Service
{
    public interface IWebsiteService
    {
        List<Website> GetAllWebsite();
        bool CreateWebsite(Website website);
        bool UpdateWebsite(Website website);
        bool DeleteWebsite(int Id);
    }
}

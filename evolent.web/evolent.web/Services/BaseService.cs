﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using evolent.web.Helpers;

namespace evolent.web.Services
{
    public class BaseService
    {
        #region Properties

        public static string BaseURL { get { return EvolentHelpers.GetWebConfigValue("evolentAPIURL"); } }

        #endregion        
    }
}
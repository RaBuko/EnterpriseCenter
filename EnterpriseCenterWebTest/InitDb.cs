﻿using EnterpriseCenterWeb.Models;
using NLog.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseCenterWebIntegrationTests
{
    public class InitDb
    {
        public static void InitializeDbForTests(EnterpriseCenterContext ctx)
        {
            ctx.Database.EnsureCreated();





        }


        public static void ReinitializeDbForTests(EnterpriseCenterContext ctx)
        {

        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Logging
{
    public interface ILogger
    {
        void LogMessage(string message);
        void LogEmptyLine();
        void ClearLogger();
    }
}

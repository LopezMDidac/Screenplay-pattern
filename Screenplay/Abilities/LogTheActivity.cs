using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstandingScreenplay.Screenplay.Core.Bases;
using UnderstandingScreenplay.Screenplay.Core.Interfaces;

namespace UnderstandingScreenplay.Screenplay.Abilities;

public class LogTheActivity : Ability<TextWriter>
{
    private LogTheActivity(TextWriter logger) 
    {
        Enabler = logger;
    }
    public static LogTheActivity To(TextWriter logger)
    {
        return new LogTheActivity(logger);
    }
}



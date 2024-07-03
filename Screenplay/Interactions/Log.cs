using Microsoft.Playwright;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstandingScreenplay.Screenplay.Core.Bases;
using UnderstandingScreenplay.Screenplay.Core.Interfaces;
using UnderstandingScreenplay.Sut;

namespace UnderstandingScreenplay.Screenplay.Interactions;


public class Log : Interaction<TextWriter>
{
    private string _message;

    public static Log TheMessage(string message)
    {
        return new Log() { _message = message };
    }

    public override Log PerformedBy(IActor _)
    {
        Enabler.WriteLine(_message);
        return this;
    }
}


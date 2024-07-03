using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstandingScreenplay.Screenplay.Core.Bases;
using UnderstandingScreenplay.Screenplay.Core.Interfaces;
using UnderstandingScreenplay.Sut;

namespace UnderstandingScreenplay.Screenplay.Questions;

public class Presence : Question<IPage, bool>
{
    private Locator _locator;

    public static Presence Of(Locator locator)
    {
        return new Presence() { _locator = locator };
    }

    public override Presence AnsweredTo(IActor _, out bool response)
    {
        try
        {
            Assertions.Expect(_locator[Enabler!]).ToBeVisibleAsync().Wait();
            response = true;
        }
        catch (Exception e)
        {
            response = false;
        }
        return this;
    }
}

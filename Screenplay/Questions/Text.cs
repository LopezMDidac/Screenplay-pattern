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
public class Text : Question<IPage, string[]>
{
    private Locator _locator;

    public static Text Of(Locator locator)
    {
        return new Text() { _locator = locator };
    }

    public override Text AnsweredTo(IActor _, out string[] response)
    {
        try
        {
            _locator[Enabler!].AllAsync().Result.ToList().ForEach( loc => Assertions.Expect(loc).ToBeVisibleAsync().Wait());
            response = _locator[Enabler].AllTextContentsAsync().Result.ToArray();
        }
        catch (Exception e)
        {
            response = [];
        }
        return this;
    }
}

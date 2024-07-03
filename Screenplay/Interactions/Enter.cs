using Microsoft.Playwright;
using UnderstandingScreenplay.Screenplay.Core.Bases;
using UnderstandingScreenplay.Screenplay.Core.Interfaces;
using UnderstandingScreenplay.Sut;

namespace UnderstandingScreenplay.Screenplay.Interactions;

public class Enter : Interaction<IPage>
{
    private string? _value;
    private Locator? _locator;

    public static Enter TheValue(string value)
    {
        return new Enter() { _value = value };
    }

    public Enter Into(Locator locator)
    {
        _locator = locator;
        return this;
    }

    public override Enter PerformedBy(IActor _)
    {
        _locator![Enabler!].FillAsync(_value!).Wait();
        return this;
    }
}

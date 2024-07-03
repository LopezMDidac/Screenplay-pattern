using Microsoft.Playwright;
using UnderstandingScreenplay.Screenplay.Core.Bases;

namespace UnderstandingScreenplay.Screenplay.Abilities;

public class BrowseTheWeb : Ability<IPage>
{
    private IPlaywright _playwright;
    private IBrowser _browser;
    private BrowseTheWeb(IPage page) { Enabler = page; }
    public static BrowseTheWeb With(IPage page)
    {
        return new BrowseTheWeb(page);
    }
    public static BrowseTheWeb WithNewSession()
    {
        var playwright = Playwright.CreateAsync().Result;
        var browser = playwright.Chromium.LaunchAsync(new()
        {
            Headless = false,
            SlowMo = 50,
        }).Result;

        var page = browser.NewPageAsync().Result;
        var ability =  new BrowseTheWeb(page);
        ability._playwright = playwright;
        ability._browser = browser;
        return ability;
    }
    public async Task<BrowseTheWeb> Dispose()
    {
        await _browser.DisposeAsync();
        _playwright.Dispose();
        return this;
    }
}


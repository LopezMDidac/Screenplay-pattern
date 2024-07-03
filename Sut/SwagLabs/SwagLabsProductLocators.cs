using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingScreenplay.Sut.SwagLabs;

public class SwagLabsProductLocators
{
    public static Locator Header = new(page => page.Locator(".product_label"));
}

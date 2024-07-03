using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingScreenplay.Sut.Locators;

public class SwagLabsProductItemLocators
{
    public static Locator Card = new(page => page.Locator(".inventory_item"));
    public static Locator Title = new(page => page.Locator(".inventory_item_name"));
    public static Locator ActionBtn = new(page => page.Locator(".btn_inventory"));
}

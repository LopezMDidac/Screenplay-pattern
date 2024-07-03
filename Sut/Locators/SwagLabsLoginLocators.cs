using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingScreenplay.Sut.Locators;

public class SwagLabsLoginLocators
{
    public static Locator LoginForm = new(page => page.Locator(".login_wrapper"));
    public static Locator UserField = new(page => page.Locator("[data-test=\"username\"]"));
    public static Locator PasswordField = new(page => page.Locator("[data-test=\"password\"]"));
    public static Locator SubmitBtn = new(page => page.GetByRole(AriaRole.Button, new() { Name = "LOGIN" }));
}


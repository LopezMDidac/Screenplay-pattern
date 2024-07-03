using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;
using UnderstandingScreenplay.Screenplay.Abilities;
using UnderstandingScreenplay.Screenplay.Behaviours;
using UnderstandingScreenplay.Screenplay.Core.Bases;
using UnderstandingScreenplay.Screenplay.Interactions;
using UnderstandingScreenplay.Screenplay.Questions;
using UnderstandingScreenplay.Sut.SwagLabs;

namespace UnderstandingScreenplay.Tests;

[TestClass]
public class SampleTest : PageTest
{

    [TestMethod]
    public void SimpleLoginTestWithInteractions()
    {
        var url = "https://www.saucedemo.com/v1/";
        var expectedProducts = 6;

        var standardUser = new BasicUser("standard_user", "secret_sauce");
        standardUser.HasAbility(BrowseTheWeb.With(Page))
            .HasAbility(LogTheActivity.To(Console.Out));
        standardUser
            .Performs(Log.TheMessage($"{standardUser.Name} Navigates to url {url}"))
            .Performs(Navigate.To(url));

        Assert.IsTrue(standardUser.Answers(Presence.Of(SwagLabsLoginLocators.LoginForm)));
        standardUser
            .Performs(Log.TheMessage($"{standardUser.Name} Introduces credentials"))
            .Performs(Enter.TheValue(standardUser.Name).Into(SwagLabsLoginLocators.UserField))
            .Performs(Enter.TheValue(standardUser.Password).Into(SwagLabsLoginLocators.PasswordField))
            .Performs(Log.TheMessage($"{standardUser.Name} submits login form"))
            .Performs(Click.On(SwagLabsLoginLocators.SubmitBtn))
            .Answers(Presence.Of(SwagLabsProductLocators.Header), out var isPageLoaded)
            .Answers(Count.Of(SwagLabsProductItemLocators.Card), out var numberOfProducts);


        Assert.IsTrue(isPageLoaded);
        Assert.AreEqual(expectedProducts, numberOfProducts);
    }

    [TestMethod]
    public void SimpleLoginTestWithTasks()
    {
        var url = "https://www.saucedemo.com/v1/";
        var expectedProducts = 6;


        var standardUser = new BasicUser("standard_user", "secret_sauce");
        standardUser.HasAbility(BrowseTheWeb.With(Page))
            .HasAbility(LogTheActivity.To(Console.Out));
        standardUser
            .Performs(Log.TheMessage($"{standardUser.Name} Navigates to url {url}"))
            .Performs(Navigate.To(url));
        Assert.IsTrue(standardUser.Answers(Presence.Of(SwagLabsLoginLocators.LoginForm)));
        standardUser
            .Performs(Login.WithUser(standardUser.Name).WithPassword(standardUser.Password))
            .Answers(Presence.Of(SwagLabsProductLocators.Header), out var isPageLoaded)
            .Answers(Count.Of(SwagLabsProductItemLocators.Card), out var numberOfProducts);


        Assert.IsTrue(isPageLoaded);
        Assert.AreEqual(expectedProducts, numberOfProducts);
    }

    [TestMethod]
    public void BuyProductsFromList()
    {
        var url = "https://www.saucedemo.com/v1/";

        var buyer = new BasicUser("standard_user", "secret_sauce");
        buyer.HasAbility(BrowseTheWeb.With(Page))
            .HasAbility(LogTheActivity.To(Console.Out));
        buyer
            .Performs(Log.TheMessage($"{buyer.Name} Navigates to url {url}"))
            .Performs(Navigate.To(url));
        Assert.IsTrue(buyer.Answers(Presence.Of(SwagLabsLoginLocators.LoginForm)));

        buyer
            .Performs(Login.WithUser(buyer.Name).WithPassword(buyer.Password))
            .Answers(Text.Of(SwagLabsProductItemLocators.Title), out var availableItems)
            .Performs(AddToCart.TheProduct(availableItems.ElementAt(4)))
            .Performs(Click.On(SwagLabsProductItemLocators.Title).WithInsideText(availableItems.ElementAt(2)))
            .Performs(AddToCart.TheProduct(availableItems.ElementAt(2)).FromDetails());
    }
}



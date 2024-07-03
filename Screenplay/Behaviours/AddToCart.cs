using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstandingScreenplay.Screenplay.Core.Bases;
using UnderstandingScreenplay.Screenplay.Core.Interfaces;
using UnderstandingScreenplay.Screenplay.Interactions;
using UnderstandingScreenplay.Sut.SwagLabs;

namespace UnderstandingScreenplay.Screenplay.Behaviours;

public class AddToCart : Behaviour
{
    private string _productName;
    private bool _uniqueAddToCart;

    public static AddToCart TheProduct(string productName)
    {
        return new AddToCart() { _productName = productName, _uniqueAddToCart = false };
    }

    public AddToCart FromDetails()
    {
        _uniqueAddToCart = true;
        return this;
    }

    public override AddToCart PerformedAs(IActor actor)
    {
        actor.Performs(Log.TheMessage($"Product {_productName} is added to the cart"));
        if (_uniqueAddToCart)
        {
            actor.Performs(Click.On(SwagLabsProductItemLocators.ActionBtn));
        }
        else
        {
            actor.Performs(Click.On(SwagLabsProductItemLocators.ActionBtn).Inside(SwagLabsProductItemLocators.Card).WithSibilingText(_productName));
        }
        
        return this;
    }

}

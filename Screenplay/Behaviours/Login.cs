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

public class Login : Behaviour
{
    private string _user;
    private string _password;

    public static Login WithUser(string username)
    {
        return new Login() { _user = username };
    }

    public Login WithPassword(string password)
    {
        _password = password;
        return this;
    }

    public override Login PerformedAs(IActor actor)
    {
        actor
            .Performs(Log.TheMessage($"{_user} Introduces credentials"))
            .Performs(Enter.TheValue(_user).Into(SwagLabsLoginLocators.UserField))
            .Performs(Enter.TheValue(_password).Into(SwagLabsLoginLocators.PasswordField))
            .Performs(Log.TheMessage($"{_user} submits login form"))
            .Performs(Click.On(SwagLabsLoginLocators.SubmitBtn));
        return this;
    }

}

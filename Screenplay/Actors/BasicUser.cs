
namespace UnderstandingScreenplay.Screenplay.Core.Bases;

public class BasicUser : Actor
{
    public string Name;
    public string Password;

    public BasicUser(string name, string password) : base()
    {
        Name = name;
        Password = password;
    }
}

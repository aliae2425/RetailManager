using System;

namespace RMDesktopUI.Library
{
    public interface ILoggedInUserModel
    {
        DateTime CreateDate { get; set; }
        string Email { get; set; }
        string Id { get; set; }
        string Nom { get; set; }
        string Prenom { get; set; }
        string Token { get; set; }
    }
}
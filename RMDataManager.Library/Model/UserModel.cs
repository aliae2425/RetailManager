using System;

namespace RMDataManager.Library.DataAccess
{
    public class UserModel
    {
        public string Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace LabBook.ADO
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Permission { get; set; }
        public string Identifier { get; set; }
        public bool Active { get; set; }
        public DateTime Date { get; set; }

        public User(long id, string name, string surname, string email, string login, string password, string permission, 
            string identifier, bool active, DateTime date)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
            Login = login;
            Password = password;
            Permission = permission;
            Identifier = identifier;
            Active = active;
            Date = date;
        }

        public User() { }

        public override bool Equals(object obj)
        {
            return obj is User user &&
                   Id == user.Id &&
                   Name == user.Name &&
                   Surname == user.Surname &&
                   Email == user.Email &&
                   Login == user.Login &&
                   Permission == user.Permission &&
                   Identifier == user.Identifier &&
                   Active == user.Active &&
                   Date == user.Date;
        }

        public override int GetHashCode()
        {
            int hashCode = -793966275;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Surname);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Login);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Permission);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Identifier);
            hashCode = hashCode * -1521134295 + Active.GetHashCode();
            hashCode = hashCode * -1521134295 + Date.GetHashCode();
            return hashCode;
        }
    }
}

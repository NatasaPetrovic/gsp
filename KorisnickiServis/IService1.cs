using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Security.Cryptography;

namespace KorisnickiServis
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        public string Login(string username, string password)
        {
            Korisnik korisnik = new Korisnik(username, password);
            int validate = korisnik.ValidateUser();
            if (validate == 0)
                return "Ne postojeci korisnik";
            else if (validate == -1)
                return "Netacna lozinka";
            else if (validate == 1)
                return "Korisnik je validan";
            else
                return "Greska";
        }

        public string AddUser(string username, string password)
        {
            if (username.Length > 2 && username.Length <= 25 && password.Length > 8 && password.Length <= 20 && password.Where(char.IsUpper).Count() >= 1 && password.Where(char.IsDigit).Count() >= 1)
            {
                Korisnik korisnik = new Korisnik(username, password);
                bool insert = korisnik.InsertUser();

                if (insert)
                    return "Uspesan unos";
                else
                    return "Unos je neuspesan";
            }
            else
                return "Lozinka nije validna";
        }

        
    }

   
   
}

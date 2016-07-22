using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KorisnickiServis
{
    class Korisnik
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }

        static readonly char[] AvailableCharacters = {
    'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 
    'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 
    'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 
    'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 
    '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '-', '_'
  };
        public Korisnik(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public int ValidateUser()
        {
            string hashedPassword = "";
       
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KorisniciConn"].ConnectionString);

            SqlDataAdapter adapter = new SqlDataAdapter("getUserByUsername", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@Username", SqlDbType.VarChar, 25));
            
            adapter.SelectCommand.Parameters["@Username"].Value = Username ;
            
            DataSet ds = new DataSet();
            adapter.Fill(ds, "getUserByUsername");
            connection.Close();
            if (ds.Tables[0].Rows.Count != 0)
            {
                Salt = ds.Tables[0].Rows[0]["Salt"].ToString();
                hashedPassword = ds.Tables[0].Rows[0]["Password"].ToString();

                Password = HashPassword(Salt + Password);

                if (Password == hashedPassword)
                    return 1;
                else
                    return -1;
            }
                else
            
                    return 0;
        }

        public bool InsertUser()
        {
            Salt = GenerateIdentifier(25);
            Password = HashPassword(Salt + Password);

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KorisniciConn"].ConnectionString);

            SqlCommand cmd = new SqlCommand("insertKorisnik", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Username", SqlDbType.VarChar, 25));
            cmd.Parameters.Add(new SqlParameter("@Salt", SqlDbType.VarChar, 25));
            cmd.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar, 20));

            cmd.Parameters["@Username"].Value = Username;
            cmd.Parameters["@Salt"].Value = Salt;
            cmd.Parameters["@Password"].Value = Password;

            int returnValue = cmd.ExecuteNonQuery();
            connection.Close();
            if (returnValue != 0)
                return true;
            else
                return false;
          
        }
        internal static string GenerateIdentifier(int length)
        {
            char[] identifier = new char[length];
            byte[] randomData = new byte[length];

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(randomData);
            }

            for (int idx = 0; idx < identifier.Length; idx++)
            {
                int pos = randomData[idx] % AvailableCharacters.Length;
                identifier[idx] = AvailableCharacters[pos];
            }

            return new string(identifier);
        }

        public static String HashPassword(String value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
    }
}

using System;

namespace LegacyApp
{
    public class User
    {
        public Client Client { get; internal set; }
        public bool HasCreditLimit { get; internal set; }
        public int CreditLimit { get; internal set; }

        public User()
        {
        }

        public User(Client client)
        {
            Client = client;
        }

        public string FirstName {
            get {
                return Client.FirstName;
            }
        }
        
        public string LastName {
            get {
                return Client.LastName;
            }
        }
        
        public DateTime DateOfBirth {
            get
            {
                return Client.DateOfBirth;
            }
        }
        
    }
}
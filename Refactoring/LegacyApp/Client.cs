using System;

namespace LegacyApp
{
    public class Client
    {
        public int ClientId { get; internal set; }
        
        public string FirstName { get; internal set; }
        
        public string LastName { get; internal set; }
        
        public string Email { get; internal set; }
        
        public DateTime DateOfBirth { get; internal set; }
        
        public string Address { get; internal set; }
        
        public string Type { get; set; }
    }
}
using System.Collections.Generic;

namespace WebApiURealEstate.Models
{
    public class CreateUserRequest
    {
        public string name;
        public string email;
        public string password;        
        public string location;
        public int rooms;
        public int price;
        public List<int> types;
    }
}
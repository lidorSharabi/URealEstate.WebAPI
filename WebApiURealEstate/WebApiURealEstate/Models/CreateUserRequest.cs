namespace WebApiURealEstate.Models
{
    public class CreateUserRequest
    {
        public int id;
        public string name;
        public int rooms;
        public int location;
        public string email;
        public int price;
        public int typeId;
        public bool saved;
        public bool disliked;
    }
}
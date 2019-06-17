using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiURealEstate.Models
{
    public class Asset
    {
        public int id;
        public int typeId;
        public int rooms;
        public int meters;
        public int floor;
        public string location;
        public int price;
    }
}